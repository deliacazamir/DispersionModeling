using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DispersionModeling.API.Models
{
    public class Form
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string SourceName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; }
    }
}