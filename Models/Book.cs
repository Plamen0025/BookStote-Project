
namespace BookStore.Models
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public Guid AuthorId { get; set; }
        public Author Author { get; set; }

        public int Year { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}