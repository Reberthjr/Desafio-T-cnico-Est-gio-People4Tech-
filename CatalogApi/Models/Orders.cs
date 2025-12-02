namespace CatalogApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public required string ClientName { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public List<OrderItem> Items { get; set; } = new();
    }
}
