namespace DataImportEngine.Application.Contracts
{
    public interface ICommandResult
    {
        bool HasErrors { get; }
        IEnumerable<string> ErrorMessages { get; }
        ICommandResult AddError(string errorMesssage);
    }
}
