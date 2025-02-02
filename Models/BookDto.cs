namespace BookStore.Models
{
    public class BookDto
    {
        public string Title { get; set; } = string.Empty;
        public Guid AuthorId { get; set; }
        public int Year { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
