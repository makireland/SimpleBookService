using SimpleBookService.Web.Infra.Context;
using SimpleBookService.Web.Infra.Interfaces;
using SimpleBookService.Web.Models.Entities;

namespace SimpleBookService.Web.Infra.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BookDbContext dbContext) : base(dbContext)
        {
        }
    }
}
