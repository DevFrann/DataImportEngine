namespace DataImportEngine.Infrastructure.Manage
{
    public interface IProductRepository<T> where T : class
    {
        public Task CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(int id);
        public Task<T> GetAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync(int id);
    }
}
