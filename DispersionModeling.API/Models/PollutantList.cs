using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DispersionModeling.API.Models
{
    public class PollutantList
    {
        [Key]
        public int  PollutantListID { get; set; }
        
        public string Name { get; set; }
        public string ChemicalFormula { get; set; }
        public string Measure { get; set; }
        public bool IsCarcinogenic { get; set; }
        public bool IsOrganic { get; set; }
        public int SedimentationSpeed { get; set; }
        public bool IsGasOrSolid { get; set; }
        public int LegislativeValue { get; set; }

        public int PollutionSourceId { get; set; }
        public PollutionSource PollutionSource { get; set; }

        //public List<PollutantStation> PollutantStations { get; set; }

    }
}