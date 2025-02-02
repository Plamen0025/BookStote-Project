using BookStore.Models;
using BookStore.Repositories;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> AddBookAsync(BookDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                Year = bookDto.Year,
                AuthorId = bookDto.AuthorId,
                IsAvailable = bookDto.IsAvailable
            };

            await _bookRepository.AddAsync(book);
            await _bookRepository.SaveChangesAsync();

            return book;
        }

        public async Task<Book?> FindBookByTitleAsync(string title)
        {
            return await _bookRepository.FindByTitleAsync(title);
        }

        public async Task<Book?> GetBookById(Guid id)
        {
            return await _bookRepository.GetBookById(id);
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.GetAllBooks();
        }
    }
}