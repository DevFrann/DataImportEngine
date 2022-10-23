namespace DataImportEngine.Domain.DTOs
{
    public class CapterraEntity
    {
        public CapterraEntity()
        {
        }

        public string Name { get; set; }
        public string Tags { get; set; }
        public List<string> Categories => Tags.Split(',').ToList();
        public string Twitter { get; set; }
    }
}
