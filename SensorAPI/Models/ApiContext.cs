using Microsoft.EntityFrameworkCore;

namespace SensorAPI.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { 

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
    }
}
