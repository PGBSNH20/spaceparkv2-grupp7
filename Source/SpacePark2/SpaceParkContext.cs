using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpacePark2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2
{
    public class SpaceParkContext : DbContext
    {
        public DbSet<Parking> Parking { get; set;}
        public DbSet<ParkingHouse> ParkingHouse { get; set; }
        public DbSet<SpaceTraveller> SpaceTraveller { get; set; }
        public DbSet<StarShip> StarShip { get; set; }

        public SpaceParkContext()
        {
        }

        public SpaceParkContext(DbContextOptions<SpaceParkContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var config = builder.Build();
            var defaultConnectionString = config.GetConnectionString("Default");
            optionsBuilder.UseSqlServer(defaultConnectionString);
        }
    }
}
