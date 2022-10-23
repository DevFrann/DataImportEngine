using DataImportEngine.Application.Commands;
using DataImportEngine.Application.Contracts;
using DataImportEngine.Application.Mappers;
using DataImportEngine.Domain.DTOs;
using DataImportEngine.Domain.Enums;
using DataImportEngine.Infrastructure.Import.Repositories;
using FluentValidation;

namespace DataImportEngine.Application.Handlers
{
    public class ImportCommandHandler : IImportCommandHandler
    {
        private readonly IValidator<ImportCommand> _validator;
        private readonly IImportDataRepository<List<SoftwareAdviceEntity>> _jsonRepository;
        private readonly IImportDataRepository<List<CapterraEntity>> _yamlRepository;
        //private readonly IProductRepository<ProductDto> _productRepository;

        public ImportCommandHandler(IValidator<ImportCommand> validator,
                                    IImportDataRepository<List<SoftwareAdviceEntity>> jsonRepository,
                                    IImportDataRepository<List<CapterraEntity>> yamlRepository)
        //,IProductRepository<ProductDto> productRepository)
        {
            ArgumentNullException.ThrowIfNull(validator, nameof(validator));
            ArgumentNullException.ThrowIfNull(jsonRepository, nameof(jsonRepository));
            ArgumentNullException.ThrowIfNull(yamlRepository, nameof(yamlRepository));
            //ArgumentNullException.ThrowIfNull(productRepository, nameof(productRepository));

            _validator = validator;
            _jsonRepository = jsonRepository;
            _yamlRepository = yamlRepository;
            //_productRepository = productRepository;
        }

        public async Task<ImportCommandResult> HandleAsync(ImportCommand command)
        {
            var result = new ImportCommandResult();

            if (command == null)
            {
                result.AddError("Command is null");
                return result;
            }

            if (!command.IsValid())
            {
                result.AddError("Command is not valid");
                return result;
            }

            await _validator.ValidateAndThrowAsync(command);

            result.Products = command.Type switch
            {
                OriginTypeEnum.Capterra => (await _yamlRepository.ReadDataAsync(command.Data)).Select(DataMapper.MapDataFromYAML).ToList(),
                OriginTypeEnum.Softwareadvice => (await _jsonRepository.ReadDataAsync(command.Data)).Select(DataMapper.MapDataFromJSON).ToList(),
                _ => throw new NotImplementedException()

            };

            if (result.Products.Any())
            {
                //await SaveImportedData(result.Products);
                result.Imported = true;
            }

            return result;
        }

        //private Task SaveImportedData(List<ProductEntity> products)
        //{
        //    products.ForEach(async x => await Task.FromResult(_productRepository.CreateAsync(x)));
        //    return Task.CompletedTask;
        //}
    }
}
