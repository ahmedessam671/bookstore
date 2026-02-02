using BookStore1.Application.DTOs.Books;
using BookStore1.Domain;

namespace BookStore1.Application.Services
{
public interface IBookService
{
    Task<IEnumerable<BookDTO>> GetAllAsync(string? filterOn,
         string? filterQuery,
         string? sortBy,
         bool isAscending,
         int pageNumber,
         int pageSize);
    Task<BookDTO?> GetByIdAsync(Guid id);
    Task<BookDTO> CreateAsync(AddBookDTO dto);
        Task<BookDTO?> UpdateAsync(Guid id, UpdateBookDto dto);
        Task<bool> DeleteAsync(Guid id);
    }

}
