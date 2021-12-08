using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLeaflet.Samples.Data
{
    public class AirportDbContext : DbContext
    {
        #region Contructor
        public AirportDbContext(DbContextOptions<AirportDbContext> options)
                : base(options)
        {
        }
        #endregion
        #region Public properties
        public DbSet<Airport> Airport { get; set; }
        #endregion
        #region Overidden methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>().HasData(GetProducts());
            base.OnModelCreating(modelBuilder);
        }
        #endregion
        #region Private methods
        private List<Airport> GetProducts()
        {
            return new List<Airport>
    {
        new Airport { Id = 1001, Name = "ist"},
        new Airport { Id = 1002, Name = "ank"},
        new Airport { Id = 1003, Name = "tok"},
        new Airport { Id = 1004, Name = "çnk"}
    };
        }
        #endregion
    }
}
