using SimpleBookService.Web.Models.Dtos;

namespace SimpleBookService.Web.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDto> GetById(int id);
        Task<int> Add(CategoryDto bookDto);
        Task<CategoryDto> Update(CategoryDto entity);
    }
}
