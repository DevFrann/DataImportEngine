using System.Text;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace DataImportEngine.Infrastructure.Import.Serializers
{
    public class JSONSerializer : IJSONSerializer
    {
        public async Task<T> DeserializeAsync<T>(string data)
        {
            JObject obj = JObject.Parse(data);
            var jsonArray = obj["products"].ToString();
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonArray));
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }
    }
}
