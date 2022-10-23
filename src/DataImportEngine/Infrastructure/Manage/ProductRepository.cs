using DataImportEngine.Domain.DTOs;

namespace DataImportEngine.Infrastructure.Manage
{
    public class ProductRepository : IProductRepository<ProductEntity>
    {
        public Task CreateAsync(ProductEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductEntity>> GetAllAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductEntity> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
