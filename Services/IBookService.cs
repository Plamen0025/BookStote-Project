using BookStore.Models;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IBookService
    {
        Task<Book> AddBookAsync(BookDto book);
        Task<Book?> FindBookByTitleAsync(string title);
        Task<Book?> GetBookById(Guid id);
        Task<IEnumerable<Book>> GetBooks();
    }
}