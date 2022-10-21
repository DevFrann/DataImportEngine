namespace DataImportEngine.Application.Contracts
{
    public interface IImportDataService
    {
        public Task ExecuteAsync(string origin, string dataPath);
    }
}
