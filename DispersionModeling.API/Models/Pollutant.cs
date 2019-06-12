using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DispersionModeling.API.Models
{
    public class Pollutant
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string ChemicalFormula { get; set; }
        public string Unit { get; set; }
        public bool IsCarcinogenic { get; set; }
        public string OrganicType { get; set; }
        public double SedimentationSpeed { get; set; }
        public string  StateOfAggregation { get; set; }
        public double LegislativeValue { get; set; }

        //public List<StationType> StationTypes { get; set; }

    }
}