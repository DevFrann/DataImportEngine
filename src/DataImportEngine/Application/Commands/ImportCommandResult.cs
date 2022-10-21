using DataImportEngine.Application.Contracts;
using DataImportEngine.Domain.DTOs;

namespace DataImportEngine.Application.Commands
{
    public class ImportCommandResult : ICommandResult
    {
        private readonly List<string> _errorMessages;

        public ImportCommandResult()
        {
            Products = new List<ProductDto>();
        }

        public List<ProductDto> Products { get; set; }
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
