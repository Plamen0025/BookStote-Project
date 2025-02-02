using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService businessService)
        {
            _bookService = businessService;
        }

        [HttpGet("availability/{title}")]
        public async Task<IActionResult> CheckAvailability(string title)
        {
            var book = await _bookService.FindBookByTitleAsync(title);
            if (book is not null)
            {
                return Ok(new { Book = book });
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookDto book)
        {
            var addedBook = await _bookService.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBookById), new { id = addedBook.Id }, addedBook);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await _bookService.GetBookById(id);
            if (book is not null)
            {
                return Ok(book);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookService.GetBooks();

            return Ok(books);
        }
    }
}