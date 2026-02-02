using BookStore1.Domain;
using BookStore1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using static BookStore1.Infrastructure.Repositories.ICategoryRepositry;

namespace BookStore1.Infrastructure.Repositories
{
    public class SQLCategoryRepository : ICategoryRepositry
    {
        private readonly ApplicationDbContext _context;

        public SQLCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> DeleteAsync(string name)
        {
            var existingCategory= await _context.Categories.FirstOrDefaultAsync(x => x.Name == name);
            if (existingCategory != null)
            {
                return null;
            }
             _context.Categories.Remove(existingCategory);
            await _context.SaveChangesAsync();
            return existingCategory;
        }
    }

}
