using DispersionModeling.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DispersionModeling.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}     
        
        public DbSet<GPSLocation> GPSLocations { get; set;}
        
    }
}