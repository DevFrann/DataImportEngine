using YamlDotNet.Serialization;

namespace DataImportEngine.Infrastructure.Import.Serializers
{
    public class YAMLSerializer : IYAMLSerializer
    {
        IDeserializer _yamlDeserializer;

        public YAMLSerializer(IDeserializer yamlDeserializer)
        {
            ArgumentNullException.ThrowIfNull(yamlDeserializer, nameof(yamlDeserializer));

            _yamlDeserializer = yamlDeserializer;
        }

        public async Task<T> DeserializeAsync<T>(string data)
        {
            return await Task.FromResult(_yamlDeserializer.Deserialize<T>(data));
        }
    }
}
