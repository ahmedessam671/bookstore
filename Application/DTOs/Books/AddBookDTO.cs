namespace BookStore1.Application.DTOs.Books
{
    public class AddBookDTO
    {
        public string Title { get; set; }
        public decimal Price { get; set; }

        public string AuthorName {  get; set; }
        public string CategoryName {  get; set; }
    }
}
