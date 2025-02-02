using BookStore.Models;

namespace BookStore.Services
{
    public interface IAutorsService
    {
        Task<Author> AddAuthorAsync(AuthorDto author);
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<IEnumerable<Book>> GetAuthorBooksAsync(Guid id);
    }
}
