using System.ComponentModel.DataAnnotations;

namespace MySecrets.Dtos
{
    public class LoginDto
    {
        [Required]
        public string? KorisnickoIme { get; set; }
        [Required]
        public string? Token { get; set; }
    }
}
