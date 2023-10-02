using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SecondApiExam.Interfaces;
using SecondApiExam.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SecondApiExam.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IUserRepository _userRepository;

        public AuthController(ITokenRepository tokenRepository, IUserRepository userRepository)
        {
            _tokenRepository = tokenRepository;
            _userRepository = userRepository;
        }

        [HttpPost("CreateAccount")]
        public IActionResult CreateAccount([FromBody] User user)
        {
            try
            {
                var expectedUser = _userRepository.GetOr(user);
                if (expectedUser == null)
                {
                    _userRepository.Add(user);
                    return Ok("Пользователь успешно зарегистрирован");
                }
                else return BadRequest("Пользователь с таким именем уже есть");

            }
            catch (Exception)
            {
                return BadRequest("Ошибка при регистрации");
            }
        }
        [HttpGet("GetToken")]
        public IActionResult GetToken(string login, string password)
        {
            try
            {
                var expectedUser = _userRepository.GetByLoginAndPass(login, password);
                if (expectedUser == null)
                {
                    return Unauthorized("Такого пользователя не найдено");
                }
                else
                {
                    string token = GenerateTemporaryToken();
                    Token tokendb = new Token()
                    {
                        Value = token
                    };
                    _tokenRepository.DeleteAll();
                    _tokenRepository.Add(tokendb);
                    return Ok(token);
                }
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при авторизации");
            }
        }
        private string secretKey = Guid.NewGuid().ToString();
        private readonly ITokenRepository tokenRepository;

        private string GenerateTemporaryToken()
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, "username"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow.AddMinutes(30);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
