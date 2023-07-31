using System.ComponentModel.DataAnnotations;

namespace CookieAuthDemo.Models
{
    public class UserSignIn
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; } 
    }
}
