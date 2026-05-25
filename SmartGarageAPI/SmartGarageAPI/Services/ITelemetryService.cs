using SmartGarageAPI.DTOs;
using SmartGarageAPI.Models;

namespace SmartGarageAPI.Services
{
    public interface ITelemetryService
    {
        Task<object> AnalyzeTelemetryAsync(CreateTelemetryDto dto);

        Task<List<TelemetryData>> GetTelemetryHistoryAsync();
    }
}