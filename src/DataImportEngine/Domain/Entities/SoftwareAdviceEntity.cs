using System.Text.Json.Serialization;

namespace DataImportEngine.Domain.DTOs
{
    public class SoftwareAdviceEntity
    {
        public SoftwareAdviceEntity()
        {
            Categories = new List<string>();
        }

        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("twitter")]
        public string Twitter { get; set; }
    }
}
