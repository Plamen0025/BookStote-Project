using BookStore.Models;
using BookStore.Repositories;

namespace BookStore.Services
{
    public class AuthorsService : IAutorsService
    {
        private readonly IBookRepository _bookRepository;

        public AuthorsService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Author> AddAuthorAsync(AuthorDto authorDto)
        {
            var author = new Author 
            {
                Nationality = authorDto.Nationality,
                Name = authorDto.Name

            };

            await _bookRepository.AddAuthorAsync(author);
            await _bookRepository.SaveChangesAsync();

            return author;
        }

        public async Task<IEnumerable<Book>> GetAuthorBooksAsync(Guid id)
        {
            return await _bookRepository.GetAuthorBooksAsync(id);
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _bookRepository.GetAuthorsAsync();
        }
    }
}
