using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SmartGarageAPI.Algorithms;
using SmartGarageAPI.Data;
using SmartGarageAPI.DTOs;
using SmartGarageAPI.Hubs;
using SmartGarageAPI.Models;

namespace SmartGarageAPI.Services
{
    public class TelemetryService : ITelemetryService
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<TelemetryHub> _hub;

        public TelemetryService(
            AppDbContext context,
            IHubContext<TelemetryHub> hub)
        {
            _context = context;
            _hub = hub;
        }

        public async Task<object> AnalyzeTelemetryAsync(CreateTelemetryDto dto)
        {
            int healthScore = VehicleHealthAlgorithm.CalculateHealthScore(
                (int)dto.Rpm,
                (int)dto.Temperature,
                (int)dto.Speed,
                dto.FuelLevel
            );

            string status = "Excellent";

            if (healthScore < 80)
                status = "Good";

            if (healthScore < 60)
                status = "Warning";

            if (healthScore < 40)
                status = "Critical";

            var telemetry = new TelemetryData
            {
                Rpm = dto.Rpm,
                Temperature = dto.Temperature,
                Speed = dto.Speed,
                FuelLevel = dto.FuelLevel,
                HealthScore = healthScore,
                Status = status,
                CreatedAt = DateTime.Now
            };

            _context.TelemetryData.Add(telemetry);

            await _context.SaveChangesAsync();

            await _hub.Clients.All.SendAsync("ReceiveTelemetry", telemetry);

            return telemetry;
        }

        public async Task<List<TelemetryData>> GetTelemetryHistoryAsync()
        {
            return await _context.TelemetryData
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }
    }
}