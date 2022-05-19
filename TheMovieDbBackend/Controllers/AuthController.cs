using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TheMovieDbBackend.Core.DTO;
using TheMovieDbBackend.Core.Entity;
using TheMovieDbBackend.Service;

namespace TheMovieDbBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AuthController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDTO userForLoginDTO)
        {
            var checkUserLogin = await _unitOfWork.AuthRepository.Login(userForLoginDTO.Email, userForLoginDTO.Password);

            if (checkUserLogin == null)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            //TOKEN NELERİ TUTUCAK.
            var claims = new[]
           {
                new Claim(ClaimTypes.NameIdentifier,checkUserLogin.Id.ToString()),
                new Claim(ClaimTypes.Name, checkUserLogin.UserName + " "+ checkUserLogin.UserSurname),
                new Claim("username",checkUserLogin.UserName),
                new Claim("email",checkUserLogin.UserEmail),
                new Claim("type","d")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { token = tokenHandler.WriteToken(token), userNameSurname = checkUserLogin.UserName + " " + checkUserLogin.UserSurname });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDTO userForRegisterDTO)
        {
            try
            {
                if (await _unitOfWork.AuthRepository.UserExist(userForRegisterDTO.UserEmail))
                {
                    ModelState.AddModelError("UserEmail", "UserEmail is already exist");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.FirstOrDefault().Value);
                }

                var createUser = new User
                {
                    UserName = userForRegisterDTO.UserName,
                    UserSurname = userForRegisterDTO.UserSurname,
                    UserEmail = userForRegisterDTO.UserEmail,
                    UserPhone = userForRegisterDTO.UserPhone,
                };
                var createRegister = _unitOfWork.AuthRepository.Register(createUser, userForRegisterDTO.Password);
                await _unitOfWork.SaveAll();
                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
