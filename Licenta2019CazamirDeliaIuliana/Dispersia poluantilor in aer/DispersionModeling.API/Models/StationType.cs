using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DispersionModeling.API.Models
{
    public class StationType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

       // public List<Pollutant> Pollutants { get; set; }

    }
}