namespace DataImportEngine.Infrastructure.Import.Serializers
{
    public interface ISerializer
    {
        Task<T> DeserializeAsync<T>(string data);
    }
}
