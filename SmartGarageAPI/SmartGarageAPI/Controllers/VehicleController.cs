using Microsoft.AspNetCore.Mvc;
using SmartGarageAPI.DTOs;
using SmartGarageAPI.Services;

namespace SmartGarageAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehicles =
                await _vehicleService.GetAllVehiclesAsync();

            return Ok(vehicles);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVehicleDto dto)
        {
            var vehicle =
                await _vehicleService.CreateVehicleAsync(dto);

            return Ok(vehicle);
        }
    }
}