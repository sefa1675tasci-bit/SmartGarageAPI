namespace SmartGarageAPI.DTOs
{
    public class CreateVehicleDto
    {
        public string PlateNumber { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public int Year { get; set; }
    }
}