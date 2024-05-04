using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using SalesReport.Domain.Models;
using System.Text;
using SalesReport.Application.Dtos;
namespace SalesReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly string secretKey;

        public AuthController(IConfiguration config)
        {
            secretKey = config.GetSection("settings").GetSection("secretKey").ToString();
        }
        /// <summary>
        /// User validation method
        /// </summary>
        /// <param name="request">Email and password</param>
        /// <returns>If validation ok, return token</returns>
        /// <response code="200">User found</response>
        /// <response code="404">User not found</response>
        /// <response code="401">No authorization</response>
        [HttpPost("Validar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status401Unauthorized)]
        public IActionResult Validar([FromBody] User request)
        {

            if (request.Email == "RsmTest@test.com" && request.Password == "123")
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.Email));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokencreado = tokenHandler.WriteToken(tokenConfig);

                return StatusCode(StatusCodes.Status200OK, new { token = tokencreado });
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
            }         
        }
    }
}
