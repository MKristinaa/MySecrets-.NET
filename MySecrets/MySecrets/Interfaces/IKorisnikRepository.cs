using MySecrets.Dtos;
using MySecrets.Models;

namespace MySecrets.Interfaces
{
    public interface IKorisnikRepository
    {
        Task<Korisnik> Authenticate (string userName, string password); 
        void Register(string userName, string password);
        Task<bool> UserAlreadyExists (string userName);

    }
}
