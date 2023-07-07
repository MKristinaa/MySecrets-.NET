using System.ComponentModel.DataAnnotations;

namespace MySecrets.Dtos
{
    public class GetTajneDto
    {
        [Required]
        public string? Type { get; set; }
        public string? URL { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
