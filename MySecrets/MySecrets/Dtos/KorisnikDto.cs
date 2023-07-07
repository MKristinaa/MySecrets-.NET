using System.ComponentModel.DataAnnotations;

namespace MySecrets.Dtos
{
    public class KorisnikDto
    {
        [Required]
        public string? KorisnickoIme { get; set; }
        [Required]
        public string? Lozinka { get; set; }
    }
}
