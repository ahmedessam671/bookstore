using BookStore1.Domain;
using BookStore1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore1.Infrastructure.Repositories
{
    public class SQLBookRepositry : IBookRepositry
    {
        private readonly ApplicationDbContext _context;

        public SQLBookRepositry(ApplicationDbContext context)
        {
            _context=context;
        }
        public async Task<Book> CreateAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> DeleteAsync(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return null;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<IEnumerable<Book>> GetAllAsync(
         string? filterOn,
         string? filterQuery,
         string? sortBy,
         bool isAscending,
         int pageNumber,
         int pageSize)
        {
            var books = _context.Books
                .Include(x => x.Author)
                .Include(x => x.Category)
                .AsQueryable();

            // Filtering
            if (!string.IsNullOrWhiteSpace(filterOn) &&
                !string.IsNullOrWhiteSpace(filterQuery))
            {
                if (filterOn.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    books = books.Where(x => x.Title.Contains(filterQuery));
                }
            }

            // Sorting
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                books = isAscending
                    ? books.OrderBy(x => EF.Property<object>(x, sortBy))
                    : books.OrderByDescending(x => EF.Property<object>(x, sortBy));
            }

            // Pagination
            var skip = (pageNumber - 1) * pageSize;
            return await books.Skip(skip).Take(pageSize).ToListAsync();
        }

  

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            return await _context.Books
                .Include (x=>x.Author)
                .Include(x=>x.Category)
                .FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Book?> UpdateAsync(Guid id, Book book)
        {
            var existing = await _context.Books.FindAsync(id);
            if (existing == null) return null;

            existing.Title = book.Title;
            existing.Price = book.Price;
            existing.AuthorId = book.AuthorId;
            existing.CategoryId = book.CategoryId;

            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
