using System.ComponentModel.DataAnnotations;

namespace DispersionModeling.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        //[EmailAddress]
        [StringLength(8, MinimumLength =4, ErrorMessage = "You must specify password between 4 and 8 characters")]
        //[Phone]
        [Required]
        public string Password { get; set; }
    }
}