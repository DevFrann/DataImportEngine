using DataImportEngine.Application.Commands;
using DataImportEngine.Application.Contracts;
using DataImportEngine.Domain.DTOs;
using System.Text.RegularExpressions;

namespace DataImportEngine.Application.Services
{
    public class ImportDataService : IImportDataService
    {
        private List<string> ValidatonErrors;
        private readonly IImportCommandHandler _importCommandHandler;

        public ImportDataService(IImportCommandHandler importCommandHandler)
        {
            ValidatonErrors = new List<string>();

            ArgumentNullException.ThrowIfNull(importCommandHandler, nameof(importCommandHandler));
            _importCommandHandler = importCommandHandler;
        }

        public async Task ExecuteAsync(string origin, string dataPath)
        {
            try
            {
                ValidateInputParams(origin, dataPath);

                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/feed-products", dataPath);

                ValidateExistingFile(filePath);

                if (HasValidationErrors())
                {
                    LogErrors(ValidatonErrors);
                    return;
                }

                var data = await File.ReadAllTextAsync(filePath);
                var result = await _importCommandHandler.HandleAsync(new ImportCommand(origin, data));

                if (!result.Imported)
                {
                    LogErrors(result.ErrorMessages.ToList());
                    return;
                }

                LogImportedData(result.Products);

                return;
            }
            catch (Exception ex)
            {
                LogErrors(new List<string> { ex.Message });
                throw;
            }
        }

        private void ValidateInputParams(string origin, string dataPath)
        {
            var error = string.Empty;

            if (!Regex.IsMatch(origin, @"^[a-zA-Z0-9]+$"))
            {
                error = $"Malformed name for Origin: {origin}, letters allowed only";
                AddValidationError(error);
            }

            if (!Regex.IsMatch(dataPath, @"(.*?)\.(yaml|json)$"))
            {
                error = $"File not format not allowed: {dataPath}, allowed formats are .yml or .json";
                AddValidationError(error);
            }

            if (!dataPath.Contains(origin))
            {
                error = $"Selected origin and path not referenced each other";
                AddValidationError(error);
            }
        }

        private void ValidateExistingFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                var error = $"File not found in file path: {filePath}";
                AddValidationError(error);
            }
        }

        private void AddValidationError(string error)
        {
            ValidatonErrors.Add(error);
        }

        private bool HasValidationErrors()
        {
            return ValidatonErrors.Any();
        }

        private void LogErrors(List<string> errorList)
        {
            errorList.ForEach(Console.WriteLine);
        }

        private void LogImportedData(List<ProductDto> importedData)
        {
            importedData.ForEach(x => Console.WriteLine($"Importing: Name: {x.Name}; Categories {string.Join(",", x.Categories)}; Twitter: {x.Twitter}"));
        }
    }
}
