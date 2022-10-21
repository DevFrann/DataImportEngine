using DataImportEngine;
using DataImportEngine.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;

var servicesProvider = new ServiceCollection()
                               .AddApplicationServices()
                               .BuildServiceProvider();

var arguments = Environment.GetCommandLineArgs();
await servicesProvider.GetService<IImportDataService>()
                      .ExecuteAsync(arguments[1], arguments[2]);
return;