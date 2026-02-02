using BookStore1.Domain;

namespace BookStore1.Infrastructure.Repositories
{
    public interface ICategoryRepositry
    {

        
            Task<List<Category>> GetAllAsync();
       
            Task<Category?> GetByNameAsync(string name);
            Task<Category> CreateAsync(Category category);
        


        Task<Category?> DeleteAsync(string name);
        

    }
}
