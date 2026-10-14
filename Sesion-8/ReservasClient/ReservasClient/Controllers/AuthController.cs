using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReservasClient.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        /// <summary>Genera un token JWT de prueba.</summary>
        [HttpPost("login")]
        public IActionResult Login()
        {
            // La misma clave secreta que configuraste en Program.cs
            var secretKey = Encoding.UTF8.GetBytes("EstaEsUnaClaveSecretaMuyLargaParaPoderValidarElToken12345");
            var securityKey = new SymmetricSecurityKey(secretKey);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "Administrador"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { token = tokenString });
        }
    }
}