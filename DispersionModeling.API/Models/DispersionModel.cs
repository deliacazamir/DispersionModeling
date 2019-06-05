using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DispersionModeling.API.Models
{
    public class DispersionModel
    {
        [Key]
        public int Id { get; set; }
        public int SmokeExitSpeed { get; set; }
        public double ExitTemperature { get; set; }
        public double EmissionOfPollutantsConcentration { get; set; }
        public DateTime  CurrentDate { get; set; }
        public string TerrainType { get; set; }
        public int CloudCoverage { get; set; }
        public int AtmosphericConditions { get; set; }
        public int AirTemperature { get; set; }
        public int SolarRadiations { get; set; }
        public string WindDirection { get; set; }
        public int WindSpeedAtTenMetters { get; set; }

        // public int PollutionSourceId { get; set; }
        // public PollutionSource PollutionSource { get; set; }
        
    }
}