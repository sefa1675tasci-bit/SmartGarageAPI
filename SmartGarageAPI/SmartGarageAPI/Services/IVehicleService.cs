using SmartGarageAPI.DTOs;
using SmartGarageAPI.Models;

namespace SmartGarageAPI.Services
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> GetAllVehiclesAsync();

        Task<Vehicle> CreateVehicleAsync(CreateVehicleDto dto);
    }
}