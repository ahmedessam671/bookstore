using AutoMapper;
using BookStore1.Application.DTOs.Books;
using BookStore1.Domain;
using BookStore1.Infrastructure.Repositories;
using static BookStore1.Infrastructure.Repositories.ICategoryRepositry;

namespace BookStore1.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepositry _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepositry _categoryRepositry;
        private readonly IMapper _mapper;

        public BookService(
            IBookRepositry bookRepository,
            IAuthorRepository authorRepository,
            ICategoryRepositry categoryRepositry,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _categoryRepositry = categoryRepositry;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDTO>> GetAllAsync(string? filterOn,
         string? filterQuery,
         string? sortBy,
         bool isAscending =true,
         int pageNumber=1,
         int pageSize = 10)
        {
            var books = await _bookRepository.GetAllAsync(filterOn,filterQuery,sortBy,isAscending,pageNumber,pageSize);
            return _mapper.Map<List<BookDTO>>(books);
        }

        public async Task<BookDTO> CreateAsync(AddBookDTO dto)
        {
            var author = await _authorRepository.GetByNameAsync(dto.AuthorName);
            if (author == null)
            {
                author = await _authorRepository.CreateAsync(
                    new Author { Name = dto.AuthorName });
            }

            var category = await _categoryRepositry.GetByNameAsync(dto.CategoryName);
            if (category == null)
            {
                category = await _categoryRepositry.CreateAsync(
                    new Category { Name = dto.CategoryName });
            }

            var book = new Book
            {
                Title = dto.Title,
                Price = dto.Price,
                AuthorId = author.Id,
                CategoryId = category.Id
            };

            var createdBook = await _bookRepository.CreateAsync(book);

            return _mapper.Map<BookDTO>(createdBook);
        }

        public async Task<BookDTO?> GetByIdAsync(Guid id)
        {
            var regionDomain = await _bookRepository.GetByIdAsync(id);
            if (regionDomain == null)
            {
                return null;
            }
            var regionDto = _mapper.Map<BookDTO>(regionDomain);

            return regionDto;


        }
        public async Task<BookDTO?> UpdateAsync(Guid id, UpdateBookDto dto)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                return null;

            var author = await _authorRepository.GetByNameAsync(dto.AuthorName)
                ?? await _authorRepository.CreateAsync(new Author { Name = dto.AuthorName });

            var category = await _categoryRepositry.GetByNameAsync(dto.CategoryName)
                ?? await _categoryRepositry.CreateAsync(new Category { Name = dto.CategoryName });

            book.Title = dto.Title;
            book.Price = dto.Price;
            book.AuthorId = author.Id;
            book.CategoryId = category.Id;

            await _bookRepository.UpdateAsync(id,book);

            return _mapper.Map<BookDTO>(book);
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                return false;

            await _bookRepository.DeleteAsync(id);
            return true;
        }


    }
}
