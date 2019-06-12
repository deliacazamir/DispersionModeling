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
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)    
        {                                                 
            modelBuilder.Entity<StationTypePollutant>()             
                .HasKey(x => new {x.PollutantID, x.StationTypeID});
        }  

    }
}