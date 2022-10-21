namespace DataImportEngine.Application.Contracts
{
    public interface ICommandHandler<in TCommand, TCommandResult>
    {
        Task<TCommandResult> HandleAsync(TCommand command);
    }
}
