using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySecrets.Dtos
{
    public class TajneDto
    {
        [ForeignKey("Korisnik")]
        public int IdKorisnika { get; set; }
        [Required]
        public string? Type { get; set; }
        public string? URL { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
