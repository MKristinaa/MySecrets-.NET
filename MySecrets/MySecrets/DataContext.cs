using Microsoft.EntityFrameworkCore;
using MySecrets.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MySecrets
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Korisnik>? Korisnici { get; set; }
        public DbSet<Tajne>? Tajne { get; set; }
    }
}
