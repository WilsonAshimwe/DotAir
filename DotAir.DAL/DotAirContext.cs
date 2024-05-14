using DotAir.DAL.Seeders;
using DotAir.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotAir.DAL
{
    public class DotAirContext : DbContext
    {
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Airport> Aiports { get; set; }

        public DotAirContext(DbContextOptions options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>().HasData(DataSeeders.InitAirports());
            modelBuilder.Entity<Flight>().HasData(DataSeeders.InitFlights());
            modelBuilder.Entity<Plane>().HasData(DataSeeders.InitPlanes());
        }
    }
}
