using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using DataImportEngine.Infrastructure.Import.Repositories;
using DataImportEngine.Infrastructure.Import.Serializers;
using DataImportEngine.Domain.DTOs;
using Microsoft.Extensions.DependencyInjection;
using DataImportEngine.Infrastructure.Manage;

namespace DataImportEngine
{
    public static class ServiceCollectionExtensions
    {
        private static IDeserializer CreateYamlDeserializer() => new DeserializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance)
                                                                  .Build();
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    => services.AddSingleton(CreateYamlDeserializer())
               .AddSingleton<IYMLSerializer, YMLSerializer>()
               .AddSingleton<IJSONSerializer, JSONSerializer>()
               .AddSingleton<IImportDataRepository<List<SoftwareAdviceDto>>, JSONRepository>()
               .AddSingleton<IImportDataRepository<List<CapterraDto>>, YMLRepository>()
               .AddSingleton<IProductRepository<ProductDto>, ProductRepository>();
    }
}
