﻿using Application.Commands.User;
using Application.IRepositories.EntititesRepositories.IEntitiesRepositories;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Books.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : Books.V1.UsersController
    {
        private IUserApplicationCommand services;
        public UsersController(IUserApplicationCommand userService) : base(userService)
        {
            services = userService;
        }
        [HttpPost]
        public IActionResult SignUp([Bind("Username","Email","Password")]CreateUserCommand createUserCommand)
        {
            if (createUserCommand != null)
            {
                var cliams = new List<Claim>()
                {
                    new Claim("Username",createUserCommand.Username),
                    new Claim("Email",createUserCommand.Email),
                };
                string key = "{267DC4ED-5334-4C50-A007-DC3A8396462A}";
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var credentials = new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer:"test",
                    audience:"test",
                    expires:DateTime.Now.AddMinutes(15),
                    notBefore:DateTime.Now,
                    claims:cliams,
                    signingCredentials:credentials
                    );
                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                createUserCommand.Token = jwtToken;
                services.AddUser(createUserCommand);

                return Ok(jwtToken);
            }
            return BadRequest();
        }

    }
}
