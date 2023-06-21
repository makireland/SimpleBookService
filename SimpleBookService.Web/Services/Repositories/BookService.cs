using SimpleBookService.Web.Infra.Interfaces;
using SimpleBookService.Web.Models.Dtos;
using SimpleBookService.Web.Models.Entities;
using SimpleBookService.Web.Services.Interfaces;

namespace SimpleBookService.Web.Services.Repositories
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> Add(BookDto bookDto, CategoryDto categoryDto)
        {

            var bookEntity = ConvertToBookEntity(bookDto);
            var categoryEntity = ConvertToCategoryEntity(categoryDto);

            _categoryRepository.cate .Add(categoryEntity); // Associa a categoria ao livro

            await _bookRepository.Add(bookEntity); // Adiciona o livro ao repositório

            return await _bookRepository.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<BookDto>> GetAll()
        {
           return (IEnumerable<BookDto>)await _bookRepository.GetAll();
        }

        public async Task<BookDto> GetById(int id)
        {
            var bookIdRep = await _bookRepository.GetById(id);

            var bookDto = new BookDto()
            {
                Id = bookIdRep.Id,
                Name = bookIdRep.Name,
                Author = bookIdRep.Author,
                Description = bookIdRep.Description,
                Registration = bookIdRep.Registration,
                CategoriesDto = new Category(bookIdRep.Category.Id, bookIdRep.Category.BookId, bookIdRep.Category.Name)
            };

            return bookDto;
        }


        public Task<bool> Update(BookDto entity)
        {
            throw new NotImplementedException();
        }

        public Book ConvertToBookEntity(BookDto bookDto)
        {
            var bookEntity = new Book
            {
                Id = bookDto.Id,
                Name = bookDto.Name,
                Author = bookDto.Author,
                Description = bookDto.Description,
                Registration = bookDto.Registration
            };

            return bookEntity;
        }

        public Category ConvertToCategoryEntity(CategoryDto categoryDto)
        {
            var categoryEntity = new Category
            {
                Id = categoryDto.Id,
                BookId = categoryDto.BookId,
                Name = categoryDto.Name
            };

            return categoryEntity;
        }
    }
}
