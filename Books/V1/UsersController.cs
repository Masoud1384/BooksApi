using Application.IRepositories.EntititesRepositories.IEntitiesRepositories;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace Books.V1
{
    public class UsersController : Controller
    {
        private IUserApplicationCommand _userService;
        public UsersController(IUserApplicationCommand userService)
        {
            _userService = userService;
        }
    }
}
