using System.Data.Entity;

namespace DeliveryApplication.Models
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
    }
}