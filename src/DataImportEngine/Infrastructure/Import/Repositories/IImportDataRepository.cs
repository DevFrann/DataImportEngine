namespace DataImportEngine.Infrastructure.Import.Repositories
{
    public interface IImportDataRepository<T> where T : class
    {
        public Task<T> ReadDataAsync(string data);
    }
}
