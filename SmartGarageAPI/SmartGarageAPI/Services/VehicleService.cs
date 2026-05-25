using Microsoft.EntityFrameworkCore;
using SmartGarageAPI.Data;
using SmartGarageAPI.DTOs;
using SmartGarageAPI.Models;

namespace SmartGarageAPI.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly AppDbContext _context;

        public VehicleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Vehicle>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> CreateVehicleAsync(CreateVehicleDto dto)
        {
            var vehicle = new Vehicle
            {
                PlateNumber = dto.PlateNumber,
                Brand = dto.Brand,
                Model = dto.Model,
                Year = dto.Year,
                CreatedAt = DateTime.Now
            };

            _context.Vehicles.Add(vehicle);

            await _context.SaveChangesAsync();

            return vehicle;
        }
    }
}