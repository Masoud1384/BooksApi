using Application.Commands.Books;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
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
            var result = _bookApplicationContract.SelectAllBooks();
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
            var result = _bookApplicationContract.Update(updateBookCommand);
            if (result > 0)
            {
                var uri = Url.Action(nameof(Get), "Book", result, Request.Protocol);
                return StatusCode(204, uri);
            }
            return BadRequest();
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
