namespace DispersionModeling.API.Models
{
    public class PollutantStation
    {
        public int StationTypeID{ get; set; }
        public StationType StationType { get; set; }


        public int PollutantListID { get; set; }
        public PollutantList PollutantList { get; set; }
    }
}