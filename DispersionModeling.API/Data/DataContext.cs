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
        public DbSet<PollutantList> PollutantLists { get; set; }



        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<DispersionModel>()
        //         .HasOne(p => p.PollutionSource)
        //         .WithMany(b => b.DispersionModels)
        //         .HasForeignKey(p => p.PollutionSourceId);

        //     modelBuilder.Entity<PollutionSource>()
        //         .HasOne(p => p.StationType)
        //         .WithMany(b => b.PollutionSources)
        //         .HasForeignKey(p => p.StationTypeId);

        //     modelBuilder.Entity<PollutantList>()
        //         .HasOne(p => p.PollutionSource)
        //         .WithMany(b => b.PollutantLists)
        //         .HasForeignKey(p => p.PollutionSourceId);

        //     // modelBuilder.Entity<PollutantStation>()
        //     //     .HasKey(t => new { t.StationTypeID, t.PollutantListID });

        //     //  modelBuilder.Entity<PollutantStation>()
        //     //     .HasOne(pt => pt.StationType)
        //     //     .WithMany(p => p.PollutantStations)
        //     //     .HasForeignKey(pt => pt.StationTypeID)
        //     //     .OnDelete(DeleteBehavior.Cascade);
                

        //     // modelBuilder.Entity<PollutantStation>()
        //     //     .HasOne(pt => pt.PollutantList)
        //     //     .WithMany(t => t.PollutantStations)
        //     //     .HasForeignKey(pt => pt.PollutantListID)
        //     //     .OnDelete(DeleteBehavior.Cascade);
                
        // }

    }
}