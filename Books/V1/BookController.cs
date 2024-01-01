using Application.Commands.Books;
using Application.IRepositories.EntititesRepositories.IEntitiesRepositories;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Books.V1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookApplicationContract _bookApplicationContract;

        public BookController(IBookApplicationContract bookApplicationContract)
        {
            _bookApplicationContract = bookApplicationContract;
        }

        // GET: api/<BookController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _bookApplicationContract.SelectAllBooks()
                .Select(b =>
                b.links = new List<ApiLink>
                {
                    new ApiLink(Url.Action(nameof(Get),"Author",new {b.id},Request.Scheme), "Self" , "Get"),
                new ApiLink(Url.Action(nameof(Delete),"Author",new {b.id},Request.Scheme), "Delete" , "Delete")
                });
            return Ok(result);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _bookApplicationContract.FindBookBy(b => b.Id == id);
            if (result != null)
                return Ok(result);

            return BadRequest();
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateBookCommand createBookCommand)
        {
            var result = _bookApplicationContract.AddBook(createBookCommand);
            if (result > 0)
            {
                var uri = Url.Action(nameof(Get), "Book", new { id = result }, Request.Protocol);
                return Created(uri, result);
            }
            return BadRequest();
        }

        // PUT api/<BookController>/5
        [HttpPut]
        public IActionResult Put([FromBody] UpdateBookCommand updateBookCommand)
        {
            if (updateBookCommand != null)
            {

                var result = _bookApplicationContract.Update(updateBookCommand);
                if (result > 0)
                {
                    var uri = Url.Action(nameof(Get), "Book", result, Request.Protocol);
                    return Ok(uri);
                }
            }
            return NotFound();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                var result = _bookApplicationContract.DeActiveBook(id);
                if (result)
                    return Ok(result);
            }
            return BadRequest();

        }
    }
}
