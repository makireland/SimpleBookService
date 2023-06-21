using SimpleBookService.Web.Infra.Interfaces;
using SimpleBookService.Web.Models.Dtos;
using SimpleBookService.Web.Models.Entities;
using SimpleBookService.Web.Services.Interfaces;

namespace SimpleBookService.Web.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<int> Add(CategoryDto categoryDto)
        {
            var categoryEntity = ConvertToCategoryEntity(categoryDto);

            await _categoryRepo.Add(categoryEntity);

            await _categoryRepo.SaveChangesAsync();

            return categoryEntity.Id;
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var request = await _categoryRepo.GetAll();
            return ConvertEntityListToDtoList(request);
        }

        private IEnumerable<CategoryDto> ConvertEntityListToDtoList(IEnumerable<Category> request)
        {
            var listDto = new List<CategoryDto>();

            foreach (var category in request)
            {
                listDto.Add(ConvertToCategoryDto(category));
            }

            return listDto;
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var categoryIdRep = await _categoryRepo.GetById(id);

            var categooryDto = new CategoryDto()
            {
                Id = categoryIdRep.Id,
                Name = categoryIdRep.Name
            };

            return categooryDto;
        }

        public async Task<CategoryDto> Update(CategoryDto categoryDto)
        {
            var categoryEntity = ConvertToCategoryEntity(categoryDto);

            _categoryRepo.Update(categoryEntity);

            await _categoryRepo.SaveChangesAsync();

            return categoryDto;
        }

        public Category ConvertToCategoryEntity(CategoryDto categoryDto)
        {
            var categoryEntity = new Category
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name
                
            };

            return categoryEntity;
        }

        public CategoryDto ConvertToCategoryDto(Category category)
        {
            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };

            return categoryDto;
        }
    }
}
