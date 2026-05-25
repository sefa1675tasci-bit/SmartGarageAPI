using Microsoft.EntityFrameworkCore;
using SmartGarageAPI.Models;

namespace SmartGarageAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<TelemetryData> TelemetryData { get; set; }
    }
}