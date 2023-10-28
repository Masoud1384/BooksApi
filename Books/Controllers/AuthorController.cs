using Application.Commands.Authors;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorApplicationContract _authorApplicationContract;
        public AuthorController(IAuthorApplicationContract authorApplicationContract)
        {
            _authorApplicationContract = authorApplicationContract;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _authorApplicationContract.SelectAllAuthors();
            return Ok(result);
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _authorApplicationContract.FindAuthorBy(t => t.id == id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        // POST api/<AuthorController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateAuthorCommand createAuthorCommand)
        {
            if (createAuthorCommand != null)
            {
                var result = _authorApplicationContract.AddUser(createAuthorCommand);
                var uri = Url.Action(nameof(Get), "Author", new { id = result }, Request.Protocol);
                return Created(uri, result);
            }
            return BadRequest();
        }

        // PUT api/<AuthorController>/5
        [HttpPut]
        public IActionResult Put([FromBody] UpdateAuthorCommand updateAuthorCommand)
        {
            if (updateAuthorCommand != null)
            {
                var result = _authorApplicationContract.Update(updateAuthorCommand);
                return StatusCode(204);
            }
            return BadRequest();
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                var result = _authorApplicationContract.DeActiveAuthor(id);
                var uri = Url.Action(nameof(Get), "Author", new { id = id }, Request.Protocol);
                if (result)
                {
                    return Ok(result);
                }
            }
            return BadRequest();
        }
    }
}
