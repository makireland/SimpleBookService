using SimpleBookService.Web.Infra.Interfaces;
using SimpleBookService.Web.Models.Dtos;
using SimpleBookService.Web.Models.Entities;
using SimpleBookService.Web.Services.Interfaces;

namespace SimpleBookService.Web.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<int> Add(BookDto bookDto)
        {
            var bookEntity = ConvertToBookEntity(bookDto);

            await _bookRepository.Add(bookEntity);

            await _bookRepository.SaveChangesAsync();

            return bookEntity.Id;
        }

        public async Task<IEnumerable<BookDto>> GetAll()
        {
            var request = await _bookRepository.GetAll();
            return ConvertEntityListToDtoList(request);
        }

        private IEnumerable<BookDto> ConvertEntityListToDtoList(IEnumerable<Book> request)
        {
            var listDto = new List<BookDto>();

            foreach (var book in request)
            {
                listDto.Add(ConvertToBookDto(book));
            }

            return listDto;
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
                CategoryId = bookIdRep.CategoryId
            };

            return bookDto;
        }

        public async Task<BookDto> Update(BookDto bookDto)
        {
            var bookEntity = ConvertToBookEntity(bookDto);

            _bookRepository.Update(bookEntity);

            await _bookRepository.SaveChangesAsync();

            return bookDto;
        }

        public Book ConvertToBookEntity(BookDto bookDto)
        {
            var bookEntity = new Book
            {
                Id = bookDto.Id,
                Name = bookDto.Name,
                Author = bookDto.Author,
                Description = bookDto.Description,
                Registration = bookDto.Registration,
            };

            return bookEntity;
        }

        public BookDto ConvertToBookDto(Book book)
        {
            var bookDto = new BookDto
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Description = book.Description,
                Registration = book.Registration,
                CategoryName = book.Category.Name
            };

            return bookDto;
        }
    }
}
