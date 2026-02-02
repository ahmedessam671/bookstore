namespace BookStore1.Application.DTOs.Books
{
    public class UpdateBookDto
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
    }
}
