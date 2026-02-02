namespace BookStore1.Domain
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
