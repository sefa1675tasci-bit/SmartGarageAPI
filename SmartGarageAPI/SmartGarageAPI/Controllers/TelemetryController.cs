using Microsoft.AspNetCore.Mvc;
using SmartGarageAPI.DTOs;
using SmartGarageAPI.Services;

namespace SmartGarageAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelemetryController : ControllerBase
    {
        private readonly ITelemetryService _telemetryService;

        public TelemetryController(ITelemetryService telemetryService)
        {
            _telemetryService = telemetryService;
        }

        [HttpPost("analyze")]
        public async Task<IActionResult> Analyze(CreateTelemetryDto dto)
        {
            var result = await _telemetryService.AnalyzeTelemetryAsync(dto);

            return Ok(result);
        }

        [HttpGet("history")]
        public async Task<IActionResult> History()
        {
            var data = await _telemetryService.GetTelemetryHistoryAsync();

            return Ok(data);
        }
    }
}