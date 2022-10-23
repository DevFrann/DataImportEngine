using DataImportEngine.Domain.DTOs;
using DataImportEngine.Infrastructure.Import.Serializers;

namespace DataImportEngine.Infrastructure.Import.Repositories
{
    public class YAMLRepository : IImportDataRepository<List<CapterraEntity>>
    {
        private readonly IYAMLSerializer _yamlSerializer;

        public YAMLRepository(IYAMLSerializer yamlSerializer)
        {
            ArgumentNullException.ThrowIfNull(yamlSerializer, nameof(yamlSerializer));
            _yamlSerializer = yamlSerializer;
        }

        public Task<List<CapterraEntity>> ReadDataAsync(string data)
        {
            return _yamlSerializer.DeserializeAsync<List<CapterraEntity>>(data);
        }
    }
}
