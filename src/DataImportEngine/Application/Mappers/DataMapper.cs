using DataImportEngine.Common;
using DataImportEngine.Domain.DTOs;

namespace DataImportEngine.Application.Mappers
{
    public static class DataMapper
    {
        public static ProductEntity MapDataFromJSON(SoftwareAdviceEntity data)
        {
            return new ProductEntity
            {
                Categories = data.Categories,
                Name = data.Title,
                Twitter = data.Twitter,
                Origin = Constants.SOFTWAREADVICE_ORIGIN_NAME
            };
        }

        public static ProductEntity MapDataFromYAML(CapterraEntity data)
        {
            return new ProductEntity
            {
                Categories = data.Categories,
                Name = data.Name,
                Twitter = data.Twitter,
                Origin = Constants.CAPTERRA_ORIGIN_NAME
            };
        }
    }
}
