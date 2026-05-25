namespace SmartGarageAPI.DTOs
{
    public class CreateTelemetryDto
    {
        public double Rpm { get; set; }

        public double Temperature { get; set; }

        public double Speed { get; set; }

        public int FuelLevel { get; set; }
    }
}