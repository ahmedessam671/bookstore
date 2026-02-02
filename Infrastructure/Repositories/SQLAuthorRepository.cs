using BookStore1.Domain;
using BookStore1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore1.Infrastructure.Repositories
{
    public class SQLAuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;

        public SQLAuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Author?> GetByNameAsync(string name)
        {
            return await _context.Authors
                .FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Author> CreateAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
        }


        public async Task<Author?> DeleteAsync(string name)
        {
            var existingAuthor=await _context.Authors.FirstOrDefaultAsync(x => x.Name == name);
            if (existingAuthor != null)
            {
                return null;
            }
            _context.Authors.Remove(existingAuthor);
            await _context.SaveChangesAsync();
            return existingAuthor;
        }
    }
}

