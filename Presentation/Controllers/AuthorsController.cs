using LibraryManagament.Application.Interfaces;
using LibraryManagament.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryManagament.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        
        [HttpGet("{id}")]
        public IActionResult GetAuthor(int id)
        {
            try
            {
                var author = _authorService.GetAuthor(id);
                return Ok(author);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            var authors = _authorService.GetAllAuthors();
            if (!authors.Any()) return NoContent();
            return Ok(authors);
        }


        [HttpPost]
        public IActionResult AddAuthor(Author author)
        {
            try
            {
                var added = _authorService.AddAuthor(author);
                return Ok(added);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, Author author)
        {
            try
            {
                var updated = _authorService.UpdateAuthor(id, author);
                return Ok(updated);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            try
            {
                _authorService.DeleteAuthor(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("search")]
        public IActionResult SearchAuthors([FromQuery] string name)
        {
            var authors = _authorService.GetAuthorsContains(name);
            if (!authors.Any())
                return NoContent();
            return Ok(authors);
        }
        [HttpGet("born-after")]
        public IActionResult GetAuthorsBornAfter([FromQuery] DateTime date)
        {
            var authors = _authorService.GetAuthorsBornAfter(date);
            if (!authors.Any()) return NoContent();
            return Ok(authors);
        }
    }
}
