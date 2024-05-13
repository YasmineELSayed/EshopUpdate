namespace Catalog.Api.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public String Name { get; set; } = default;
        public List<string> Category { get; set; } = new();

        public String Description { get; set; } = default;
        public String ImageFile { get; set; } = default;

        public Decimal Price { get; set; }

    }
}
