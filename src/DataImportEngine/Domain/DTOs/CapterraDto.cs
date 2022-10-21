namespace DataImportEngine.Domain.DTOs
{
    public class CapterraDto
    {
        public CapterraDto()
        {
        }

        public string Name { get; set; }
        public string Tags { get; set; }
        public List<string> Categories => Tags.Split(',').ToList();
        public string Twitter { get; set; }
    }
}
