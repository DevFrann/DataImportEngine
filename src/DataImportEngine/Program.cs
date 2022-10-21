using DataImportEngine;
using Microsoft.Extensions.DependencyInjection;

var servicesProvider = new ServiceCollection()
                               .AddApplicationServices()
                               .BuildServiceProvider();
return;