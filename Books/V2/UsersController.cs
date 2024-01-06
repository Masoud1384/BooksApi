using Application.Commands.User;
using Application.IRepositories.EntititesRepositories.IEntitiesRepositories;
using Application.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Commands.Token;
using System.Web.Http;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;

namespace Books.V2
{
    [ApiVersion("2.0")]
    [Microsoft.AspNetCore.Mvc.Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : Books.V1.UsersController
    {
        private IUserApplicationCommand services;
        private IPasswordHasher _passwordHasher;
        private IConfiguration _configuration;
        private HttpConfiguration _httpConvifguration;
        public UsersController(HttpConfiguration http,IUserApplicationCommand userService, IPasswordHasher hasher, IConfiguration configuration) : base(userService)
        {
            services = userService;
            _passwordHasher = hasher;
            _configuration = configuration;
            _httpConvifguration = http;
            _httpConvifguration.EnableCors();
        }
        [Microsoft.AspNetCore.Mvc.HttpPost("SignUp")]
        public IActionResult SignUp([FromBody] CreateUserCommand createUserCommand)
        {
            if (!services.IsUsernameEmailTaken(createUserCommand.Username, createUserCommand.Email))
            {
                var jwtToken = TokenGenerator(createUserCommand);
                return Ok(new TokenCommand {Token = jwtToken.Token,RefreshToken=jwtToken.RefreshToken});
            }
            return BadRequest();
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("Login")]
        public IActionResult Login([FromBody]LoginUserDto user)
        {
            var uservm = services.FindUserBy(user.UserName);
            var isPassOk = _passwordHasher.VerifyPassword(uservm.Password, user.Password);
            if (isPassOk && uservm.Token.Expire > DateTime.Now)
            {
                return Ok(new TokenCommand { RefreshToken = uservm.Token.RefreshToken,Token = uservm.Token.Token});
            }
            return Unauthorized();
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult GetUser(int userId)
        {
            if (userId > 0)
            {
                var user = services.FindUserBy(userId);
                if (user != null)
                {
                    return Ok(user);
                }
            }
            return NotFound();
        }

        private TokenViewModel TokenGenerator(CreateUserCommand createUserCommand)
        {
            var cliams = new List<Claim>()
                {
                    new Claim("Username",createUserCommand.Username),
                    new Claim("Email",createUserCommand.Email),
                };
            string key = "{267DC4ED-5334-4C50-A007-DC3A8396462A}";
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.Now.AddHours(int.Parse(_configuration.GetValue<string>("JWT:expire")));
            var token = new JwtSecurityToken(
                issuer: "test",
                audience: "test",
                expires: expireDate,
                notBefore: DateTime.Now,
                claims: cliams,
                signingCredentials: credentials
                );
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            var id = services.AddUser(createUserCommand);
            var tokenvm = new TokenViewModel
            {
                Expire = expireDate,
                Token = jwtToken,
                Id = id,
                RefreshToken = Guid.NewGuid().ToString(),
                RefreshTokenExp = expireDate.AddDays(5)
            };
            services.SaveToken(id, tokenvm);
            return tokenvm;
        }
    }
}
