using Microsoft.EntityFrameworkCore;
using SimpleBookService.Web.Infra.Context;
using SimpleBookService.Web.Infra.Interfaces;
using SimpleBookService.Web.Models.Entities;

namespace SimpleBookService.Web.Infra.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity, new()
    {
        private BookDbContext _dbContext;
        protected DbSet<T> _dbSet;

        public BaseRepository(BookDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            //AsNoTracking so Ef wont be monitoring it for changes
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            //AsNoTracking so Ef wont be monitoring it for changes
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public virtual void Update(T entity)
        {
           _dbContext.Update(entity);
        }
    }
}
