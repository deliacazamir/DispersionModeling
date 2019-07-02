using DispersionModeling.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DispersionModeling.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}     
        
        public DbSet<GPSLocation> GPSLocations { get; set;}
        public DbSet<User> Users { get; set;}
        public DbSet<Form> Forms { get; set;}
        public DbSet<PollutionSource> PollutionSources { get; set;}
        public DbSet<DispersionModel> DispersionModels { get; set;}
        public DbSet<StationType> StationTypes { get; set; }
        public DbSet<Pollutant> Pollutants { get; set; }
        public DbSet<StationTypePollutant> StationTypePollutants { get; set; }
        public DbSet<UserDispersionModel> UserDispersionModels { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)    
        {                                                 
            modelBuilder.Entity<StationTypePollutant>()             
                .HasKey(x => new {x.PollutantID, x.StationTypeID});

            modelBuilder.Entity<UserDispersionModel>()             
                .HasKey(x => new {x.UserID, x.DispersionModelID});

            modelBuilder.Entity<GPSLocation>()
            .HasKey(o => new { o.Latitude, o.Longitude, o.PollutantID });
        }  

    }
}