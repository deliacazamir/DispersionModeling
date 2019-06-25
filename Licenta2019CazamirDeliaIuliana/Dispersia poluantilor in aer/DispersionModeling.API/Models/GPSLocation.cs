using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DispersionModeling.API.Models
{
    public class GPSLocation
    {
        [Key, Column(Order = 0)]
        public double Latitude { get; set; }
         [Key, Column(Order = 1)]
        public double Longitude { get; set; }   
        public double Concentration { get; set; }
         [Key, Column(Order = 2)]
        public int PollutantID { get; set; }
    }
}