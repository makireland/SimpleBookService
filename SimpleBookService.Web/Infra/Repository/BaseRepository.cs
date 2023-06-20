using Microsoft.EntityFrameworkCore;
using SimpleBookService.Web.Infra.Context;
using SimpleBookService.Web.Infra.Interfaces;

namespace SimpleBookService.Web.Infra.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private BookDbContext _dbContext;
        protected DbSet<T> _dbSet;

        public BaseRepository(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
           _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }
    }
}
