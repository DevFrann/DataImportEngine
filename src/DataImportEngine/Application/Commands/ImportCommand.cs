using DataImportEngine.Common;
using DataImportEngine.Domain.Enums;

namespace DataImportEngine.Application.Commands
{
    public class ImportCommand
    {
        public ImportCommand(string origin, string data)
        {
            Origin = origin;
            Data = data;
        }

        public string Origin { get; set; }
        public string Data { get; set; }
        public OriginTypeEnum Type => Origin.ToUpperInvariant().Contains(Constants.CAPTERRA_ORIGIN_NAME) ? OriginTypeEnum.Capterra : OriginTypeEnum.Softwareadvice; //Future will be a switch maybe
        public bool IsValid() => !string.IsNullOrEmpty(Origin) && !string.IsNullOrEmpty(Data);
    }
}
