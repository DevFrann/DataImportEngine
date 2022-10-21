using DataImportEngine.Domain.DTOs;
using DataImportEngine.Infrastructure.Import.Serializers;

namespace DataImportEngine.Infrastructure.Import.Repositories
{
    public class YAMLRepository : IImportDataRepository<List<CapterraDto>>
    {
        private readonly IYAMLSerializer _yamlSerializer;

        public YAMLRepository(IYAMLSerializer yamlSerializer)
        {
            ArgumentNullException.ThrowIfNull(yamlSerializer, nameof(yamlSerializer));
            _yamlSerializer = yamlSerializer;
        }

        public Task<List<CapterraDto>> ReadDataAsync(string data)
        {
            return _yamlSerializer.DeserializeAsync<List<CapterraDto>>(data);
        }
    }
}
