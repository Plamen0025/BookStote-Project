using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private readonly IAutorsService _authorsService;

        public AuthorsController(IAutorsService businessService)
        {
            _authorsService = businessService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] AuthorDto author)
        {
            var addedAuthor = await _authorsService.AddAuthorAsync(author);
            return CreatedAtAction(nameof(AddAuthor), new { id = addedAuthor.Id }, addedAuthor);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorBooksById(Guid id)
        {
            var books = await _authorsService.GetAuthorBooksAsync(id);

            return Ok(books);
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _authorsService.GetAuthorsAsync();

            return Ok(authors);
        }
    }
}
