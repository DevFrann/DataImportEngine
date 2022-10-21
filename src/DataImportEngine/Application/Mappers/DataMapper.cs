using DataImportEngine.Common;
using DataImportEngine.Domain.DTOs;

namespace DataImportEngine.Application.Mappers
{
    public static class DataMapper
    {
        public static ProductDto MapDataFromJSON(SoftwareAdviceDto data)
        {
            return new ProductDto
            {
                Categories = data.Categories,
                Name = data.Title,
                Twitter = data.Twitter,
                Origin = Constants.SOFTWAREADVICE_ORIGIN_NAME
            };
        }

        public static ProductDto MapDataFromYML(CapterraDto data)
        {
            return new ProductDto
            {
                Categories = data.Categories,
                Name = data.Name,
                Twitter = data.Twitter,
                Origin = Constants.CAPTERRA_ORIGIN_NAME
            };
        }
    }
}
