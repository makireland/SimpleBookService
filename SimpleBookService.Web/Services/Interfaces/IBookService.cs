using SimpleBookService.Web.Models.Dtos;

namespace SimpleBookService.Web.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAll();
        Task<BookDto> GetById(int id);
        Task<int> Add(BookDto bookDto);
        Task<bool> Update(BookDto entity);

    }
}
