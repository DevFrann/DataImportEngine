using DataImportEngine.Domain.DTOs;

namespace DataImportEngine.Infrastructure.Manage
{
    public class ProductRepository : IProductRepository<ProductDto>
    {
        public Task CreateAsync(ProductDto entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetAllAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
