using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MySecrets.Dtos;
using MySecrets.Interfaces;
using MySecrets.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MySecrets.Controllers
{
    public class KorisnikController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IConfiguration configuration;

        public KorisnikController(IUnitOfWork uow, IConfiguration configuration)
        {
            this.uow = uow;
            this.configuration = configuration;
        }


        [HttpPost("/login")]
        public async Task<IActionResult> Login(KorisnikDto loginReq)
        {

            Console.WriteLine(loginReq.KorisnickoIme);

            var user = await uow.KorisnikRepository.Authenticate(loginReq.KorisnickoIme!, loginReq.Lozinka!);

            if (user == null)
            {
                return Ok(null);
               
            }

            var login = new LoginDto();
            login.KorisnickoIme = user.KorisnickoIme;
            login.Token = CreateJWT(user);
            return Ok(login);
        }

        private string CreateJWT(Korisnik korisnik)
        {
            var secretKey = configuration.GetSection("AppSettings:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8
                     .GetBytes(secretKey!));

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, korisnik.KorisnickoIme),
                new Claim(ClaimTypes.NameIdentifier, korisnik.Id.ToString()),
            };

            var signingCredentials = new SigningCredentials(
               key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
        /*[HttpPost("post")]
        public async Task<IActionResult> PostAsync(KorisnikDto korisnik)
        {
            uow.KorisnikRepository.Register(korisnik);
            await uow.SaveAsync();
            return Ok(korisnik);
        }
        */

        [HttpPost("/register")]
        public async Task<IActionResult> Register(KorisnikDto loginReq)
        {
            if (await uow.KorisnikRepository.UserAlreadyExists(loginReq.KorisnickoIme!))
                return BadRequest("User vec postoji");

            uow.KorisnikRepository.Register(loginReq.KorisnickoIme!, loginReq.Lozinka!);
            await uow.SaveAsync();
            return Ok(loginReq);
        }

    }
}
