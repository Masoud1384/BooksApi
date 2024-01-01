using Application.Commands.User;
using Application.IRepositories.EntititesRepositories.IEntitiesRepositories;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
       

    }
}
