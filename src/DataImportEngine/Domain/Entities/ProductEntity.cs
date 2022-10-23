namespace DataImportEngine.Domain.DTOs
{
    public class ProductEntity
    {
        public ProductEntity()
        {
        }

        protected ProductEntity(Guid id, string name, List<string> categories, string twitter, string origin)
        {
            Id = id;
            Name = name;
            Categories = categories;
            Twitter = twitter;
            Origin = origin;
        }

        public Guid Id { get; private set; }
        public List<string> Categories { get; set; }
        public string Name { get; set; }
        public string Twitter { get; set; }
        public string Origin { get; set; }
    }
}
