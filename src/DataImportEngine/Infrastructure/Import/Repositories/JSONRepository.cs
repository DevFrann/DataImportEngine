using DataImportEngine.Domain.DTOs;
using DataImportEngine.Infrastructure.Import.Serializers;

namespace DataImportEngine.Infrastructure.Import.Repositories
{
    public class JSONRepository : IImportDataRepository<List<SoftwareAdviceEntity>>
    {
        private readonly IJSONSerializer _jsonSerializer;

        public JSONRepository(IJSONSerializer jsonSerializer)
        {
            ArgumentNullException.ThrowIfNull(jsonSerializer, nameof(jsonSerializer));
            _jsonSerializer = jsonSerializer;
        }

        public Task<List<SoftwareAdviceEntity>> ReadDataAsync(string data)
        {
            return _jsonSerializer.DeserializeAsync<List<SoftwareAdviceEntity>>(data);
        }
    }
}
