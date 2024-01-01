using Application.IRepositories.EntititesRepositories.IEntitiesRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthorController : V1.AuthorController
    {
        public AuthorController(IAuthorApplicationContract authorApplicationContract) : base(authorApplicationContract)
        {
        }
    }
}
