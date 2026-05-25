namespace SmartGarageAPI.Models
{
    public class TelemetryData
    {
        public int Id { get; set; }

        public double Rpm { get; set; }

        public double Temperature { get; set; }

        public double Speed { get; set; }

        public int FuelLevel { get; set; }

        public int HealthScore { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}