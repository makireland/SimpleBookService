using Microsoft.EntityFrameworkCore;
using SimpleBookService.Web.Infra.Context;
using SimpleBookService.Web.Infra.Interfaces;
using SimpleBookService.Web.Models.Entities;

namespace SimpleBookService.Web.Infra.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(BookDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Book>> GetAll()
        {
            return await _dbSet.Include(x => x.Category).ToListAsync();
        }
    }
}
