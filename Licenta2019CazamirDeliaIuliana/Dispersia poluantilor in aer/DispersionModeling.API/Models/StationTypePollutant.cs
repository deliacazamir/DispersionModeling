namespace DispersionModeling.API.Models
{
    public class StationTypePollutant
    {
        public int StationTypeID { get; set; }
        public int PollutantID { get; set; }

        public StationType StationType { get; set; }
        public Pollutant Pollutant { get; set; }
    }
}