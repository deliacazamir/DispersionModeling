using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DispersionModeling.API.Models
{
    public class StationType
    {
        [Key]
        public int StationTypeID { get; set; }
        public string Name { get; set; }

        public List<PollutionSource> PollutionSources { get; set; }

        //public List<PollutantStation> PollutantStations { get; set; }
    }
}