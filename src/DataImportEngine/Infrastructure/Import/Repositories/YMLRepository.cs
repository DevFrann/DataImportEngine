using DataImportEngine.Domain.DTOs;
using DataImportEngine.Infrastructure.Import.Serializers;

namespace DataImportEngine.Infrastructure.Import.Repositories
{
    public class YMLRepository : IImportDataRepository<List<CapterraDto>>
    {
        private readonly IYMLSerializer _ymlSerializer;

        public YMLRepository(IYMLSerializer ymlSerializer)
        {
            ArgumentNullException.ThrowIfNull(ymlSerializer, nameof(ymlSerializer));
            _ymlSerializer = ymlSerializer;
        }

        public Task<List<CapterraDto>> ReadDataAsync(string data)
        {
            return _ymlSerializer.DeserializeAsync<List<CapterraDto>>(data);
        }
    }
}
