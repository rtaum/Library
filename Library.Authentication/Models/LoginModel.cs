using System.ComponentModel.DataAnnotations;

namespace Library.Authentication.Models
{
    public class LoginModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
