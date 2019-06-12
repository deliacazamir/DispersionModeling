using System.ComponentModel.DataAnnotations;

namespace DispersionModeling.API.Models
{
    public class STP
    {
        [Key]
        public int Id { get; set; }
        public int StationTypeID { get; set; }
        public int PollutantID { get; set; }
    }
}