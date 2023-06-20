using SimpleBookService.Web.Entities;
using SimpleBookService.Web.Infra.Context;
using SimpleBookService.Web.Infra.Interfaces;

namespace SimpleBookService.Web.Infra.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(BookDbContext dbContext) : base(dbContext)
        {
        }
    }
}
