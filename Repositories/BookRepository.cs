using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> AddAsync(Book book)
        {
            await _dbContext.AddAsync(book);
            return book;
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            await _dbContext.AddAsync(author);
            return author;
        }

        public async Task<Book?> FindByTitleAsync(string title)
        {
            return await _dbContext.Books.FirstOrDefaultAsync(b => b.Title.ToLower() == title.ToLower());
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAuthorBooksAsync(Guid id)
        {
            return await _dbContext.Books.Where(x => x.AuthorId == id).ToListAsync();
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _dbContext.Author.ToListAsync();
        }

        public async Task<Book?> GetBookById(Guid id)
        {
            return await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}