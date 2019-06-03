using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DispersionModeling.API.Models
{
    public class PollutionSource
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Altitude { get; set; }
        public double ChimneyHeight { get; set; }
        public double ChimneyDiameter { get; set; }
        public double MaxDistance { get; set; }

        public List<DispersionModel> DispersionModels { get; set; }
         public List<PollutantList> PollutantLists { get; set; }

        public int StationTypeId { get; set; }
        public StationType StationType { get; set; }
    }
}