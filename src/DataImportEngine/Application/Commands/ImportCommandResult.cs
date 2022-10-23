using DataImportEngine.Application.Contracts;
using DataImportEngine.Domain.DTOs;

namespace DataImportEngine.Application.Commands
{
    public class ImportCommandResult : ICommandResult
    {
        private readonly List<string> _errorMessages;

        public ImportCommandResult()
        {
            _errorMessages = new List<string>();
            Products = new List<ProductEntity>();
        }

        public List<ProductEntity> Products { get; set; }
        public bool Imported { get; set; }
        public bool HasErrors => ErrorMessages.Any();
        public IEnumerable<string> ErrorMessages => _errorMessages;

        public ICommandResult AddError(string errorMesssage)
        {
            _errorMessages.Add(errorMesssage);
            return this;
        }
    }
}
