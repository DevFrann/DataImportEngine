using YamlDotNet.Serialization;

namespace DataImportEngine.Infrastructure.Import.Serializers
{
    public class YMLSerializer : IYMLSerializer
    {
        IDeserializer _ymlDeserializer;

        public YMLSerializer(IDeserializer ymlDeserializer)
        {
            ArgumentNullException.ThrowIfNull(ymlDeserializer, nameof(ymlDeserializer));

            _ymlDeserializer = ymlDeserializer;
        }

        public async Task<T> DeserializeAsync<T>(string data)
        {
            return await Task.FromResult(_ymlDeserializer.Deserialize<T>(data));
        }
    }
}
