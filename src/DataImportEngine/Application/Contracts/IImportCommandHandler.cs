using DataImportEngine.Application.Commands;

namespace DataImportEngine.Application.Contracts
{
    public interface IImportCommandHandler : ICommandHandler<ImportCommand, ImportCommandResult>
    {
    }
}
