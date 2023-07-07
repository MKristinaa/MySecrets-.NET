using System.ComponentModel.DataAnnotations;

namespace MySecrets.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        [Required]
        public string? KorisnickoIme { get; set; }
        [Required]
        public byte[]? Lozinka { get; set; }
        public byte[]? LozinkaKljuc { get; set; }
    }
}
