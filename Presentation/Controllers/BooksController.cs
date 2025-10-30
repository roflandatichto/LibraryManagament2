using LibraryManagament.Application.Interfaces;
using LibraryManagament.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryManagament.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            try
            {
                var book = _bookService.GetBook(id);
                return Ok(book);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllBooks([FromQuery] int? AuthorId)
        {
            IEnumerable<Book> books;

            if (AuthorId.HasValue)
                books = _bookService.GetAllBooks(AuthorId);
            else
                books = _bookService.GetAllBooks();

            if (!books.Any())
                return NoContent();

            return Ok(books);
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            try
            {
                var added = _bookService.AddBook(book);
                return Ok(added);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

      
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            try
            {
                var updated = _bookService.UpdateBook(id, book);
                return Ok(updated);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

      
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                _bookService.DeleteBook(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("search")]
        public IActionResult GetBooksByTitle([FromQuery] string title)
        {
            var books = _bookService.GetBooksByTitle(title);
            if (!books.Any()) return NoContent();
            return Ok(books);
        }

        [HttpGet("after")]
        public IActionResult GetBooksPublishedAfter([FromQuery] int year)
        {
            var books = _bookService.GetBooksPublishedAfter(year);
            if (!books.Any()) return NoContent();
            return Ok(books);
        }
    }
}
