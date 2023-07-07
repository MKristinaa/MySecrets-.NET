using Microsoft.EntityFrameworkCore;
using MySecrets.Interfaces;
using MySecrets.Models;
using System.Security.Cryptography;

namespace MySecrets.Repo
{
    public class KorisnikRepository : IKorisnikRepository
    {
        private readonly DataContext dc;

        public KorisnikRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public async Task<Korisnik> Authenticate(string userName, string passwordText)
        {
            var user = await dc.Korisnici!.FirstOrDefaultAsync(x => x.KorisnickoIme == userName);

            if (user == null || user.LozinkaKljuc == null)
                return null!;

            if (!MatchPasswordHash(passwordText, user.Lozinka, user.LozinkaKljuc))
                return null!;

            return user;

        }

        private bool MatchPasswordHash(string passwordText, byte[]? password, byte[]? passwordKey)
        {
            using (var hmac = new HMACSHA512(passwordKey))
            {
                var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordText));

                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (passwordHash[i] != password[i])
                        return false;
                }

                return true;
            }
        }
        public void Register(string userName, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Lozinka nije unesena ili nije valjana.");
            }
            else
            {
                byte[] passwordHash, passwordKey;

                using (var hmac = new HMACSHA512())
                {
                    passwordKey = hmac.Key;
                    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                }

                Korisnik user = new Korisnik();
                user.KorisnickoIme = userName;
                user.Lozinka = passwordHash;
                user.LozinkaKljuc = passwordKey;

                dc.Korisnici!.Add(user);
            }
        }

        public async Task<bool> UserAlreadyExists(string userName)
        {
            return await dc.Korisnici!.AnyAsync(x => x.KorisnickoIme == userName);
        }

    }
}
