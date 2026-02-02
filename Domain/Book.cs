namespace BookStore1.Domain
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public DateTime PublishedDate { get; set; }


        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }

        // Relations
        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
        //Relations
        public Author Author { get; set; } = null!;
        public Category Category { get; set; } = null!;
    }
}
