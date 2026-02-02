using BookStore1.Domain;

namespace BookStore1.Infrastructure.Repositories
{
    public interface IBookRepositry
    {
        Task<IEnumerable<Book>> GetAllAsync(string? filterOn,
         string? filterQuery,
         string? sortBy,
         bool isAscending,
         int pageNumber,
         int pageSize);
        Task<Book?>GetByIdAsync(Guid id);
        Task<Book> CreateAsync(Book book);
        Task<Book?> UpdateAsync(Guid id,Book book);
        Task<Book> DeleteAsync(Guid id);

    }
}
