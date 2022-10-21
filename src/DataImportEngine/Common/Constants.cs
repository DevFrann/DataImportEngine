namespace DataImportEngine.Common
{
    public static class Constants
    {
        public static string CAPTERRA_ORIGIN_NAME = "CAPTERRA";
        public static string SOFTWAREADVICE_ORIGIN_NAME = "SOFTWAREADVICE";

        public static List<string> ALLOWED_FILE_EXTENSIONS => new() { ".yaml", ".json" };
    }
}
