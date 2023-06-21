namespace SimpleBookService.Web.Infra.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        void Update(T entity);
        Task<int> SaveChangesAsync();
    }
}
