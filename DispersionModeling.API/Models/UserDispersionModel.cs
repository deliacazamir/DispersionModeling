namespace DispersionModeling.API.Models
{
    public class UserDispersionModel
    {
        public int UserID { get; set; }
        public int DispersionModelID { get; set; }

        public User User { get; set; }
        public DispersionModel DispersionModel { get; set; }
    }
}