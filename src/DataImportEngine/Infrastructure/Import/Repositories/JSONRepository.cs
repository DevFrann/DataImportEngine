using DataImportEngine.Domain.DTOs;
using DataImportEngine.Infrastructure.Import.Serializers;

namespace DataImportEngine.Infrastructure.Import.Repositories
{
    public class JSONRepository : IImportDataRepository<List<SoftwareAdviceDto>>
    {
        private readonly IJSONSerializer _jsonSerializer;

        public JSONRepository(IJSONSerializer jsonSerializer)
        {
            ArgumentNullException.ThrowIfNull(jsonSerializer, nameof(jsonSerializer));
            _jsonSerializer = jsonSerializer;
        }

        public Task<List<SoftwareAdviceDto>> ReadDataAsync(string data)
        {
            return _jsonSerializer.DeserializeAsync<List<SoftwareAdviceDto>>(data);
        }
    }
}
