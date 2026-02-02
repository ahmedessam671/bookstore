namespace BookStore1.Domain
{
    public class Author
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
