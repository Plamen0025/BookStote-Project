using BookStore.Models;

namespace BookStore.Repositories
{
    public interface IBookRepository
    {
        Task<Book> AddAsync(Book book);
        Task<Book?> FindByTitleAsync(string title);
        Task<Book?> GetBookById(Guid id);
        Task<IEnumerable<Book>> GetAllBooks();

        Task<Author> AddAuthorAsync(Author author);
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<IEnumerable<Book>> GetAuthorBooksAsync(Guid id);

        Task SaveChangesAsync();
    }
}