namespace SmartGarageAPI.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public string PlateNumber { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public int Year { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
