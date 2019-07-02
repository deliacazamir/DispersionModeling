using System;
using System.ComponentModel.DataAnnotations;

namespace DispersionModeling.API.Models
{
    public class DispersionModel
    {
        [Key]
        public int Id { get; set; }
        public double SmokeExitSpeed { get; set; }
        public double ExitTemperature { get; set; }
        public double EmissionOfPollutantsConcentration { get; set; }
        public string CurrentDate { get; set; }
        public double CloudCoverage { get; set; }
        public double AtmosphericConditions { get; set; }
        public double AirTemperature { get; set; }
        public double SolarRadiations { get; set; }
        public double WindDirection { get; set; }
        public double WindSpeedAtTenMetters { get; set; }
        public bool HasMap { get; set;}
        
        public double MaxDistance { get; set; }
        public int PollutantID { get; set; }
        
    }
}