﻿using Application.Commands.Authors;
using Application.IRepositories.EntititesRepositories.IEntitiesRepositories;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Books.V1
{
    [ApiVersion("1.0")]
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
        public virtual IActionResult Get()
        {
            var result = _authorApplicationContract.SelectAllAuthors().Select(a => a.links = new List<ApiLink>
            {
                new ApiLink(Url.Action(nameof(Get),"Author",new {a.id},Request.Scheme), "Self" , "Get"),
                new ApiLink(Url.Action(nameof(Delete),"Author",new {a.id},Request.Scheme), "Delete" , "Delete")
            });
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
                if (result > 0)
                {
                    var uri = Url.Action(nameof(Get), "Author", new { id = result }, Request.Protocol);
                    return StatusCode(200, uri);
                }
            }
            return NotFound();
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                var result = _authorApplicationContract.DeActiveAuthor(id);
                var uri = Url.Action(nameof(Get), "Author", new { id }, Request.Protocol);
                if (result)
                {
                    return Ok(result);
                }
            }
            return BadRequest();
        }
    }
}
