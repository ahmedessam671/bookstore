using BookStore1.Domain;

namespace BookStore1.Infrastructure.Repositories
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();
        Task<Author?> GetByNameAsync(string name);

        Task<Author>CreateAsync(Author author);
        Task<Author?>DeleteAsync(string name);

    }
}
