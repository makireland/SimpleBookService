using SimpleBookService.Web.Entities;
using SimpleBookService.Web.Infra.Context;
using SimpleBookService.Web.Infra.Interfaces;

namespace SimpleBookService.Web.Infra.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BookDbContext dbContext) : base(dbContext)
        {
        }
    }
}
