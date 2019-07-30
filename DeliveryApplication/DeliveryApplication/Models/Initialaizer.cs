using System.Data.Entity;

namespace DeliveryApplication.Models
{
    public class Initialaizer : DropCreateDatabaseAlways<ShopContext>
    {
        protected override void Seed(ShopContext db)
        {
            db.Products.Add(new Product { Name = "Prostakvashina", Type = "Milk", Price = 1 });
            db.Products.Add(new Product { Name = "Alenka", Type = "Chockolate", Price = 2 });
            db.Products.Add(new Product { Name = "Nescafe", Type = "Coffee", Price = 8 });
            db.Products.Add(new Product { Name = "Tess", Type = "Tea", Price = 3 });
            db.Products.Add(new Product { Name = "Petruxf", Type = "Meat", Price = 5 });
            db.Products.Add(new Product { Name = "Coca", Type = "Water", Price = 2 });
            db.Products.Add(new Product { Name = "Cheese", Type = "Milk", Price = 3 });

            base.Seed(db);
        }
    }
}