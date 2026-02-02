using System.ComponentModel.DataAnnotations;

namespace BookStore1.Application.DTOs.Auth
{
    public class LoginDTO
    {
        [Required]
        [StringLength(100)]
        public string Username { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
    }
}
