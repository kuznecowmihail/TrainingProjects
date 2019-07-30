using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using DeliveryApplication.Models;

namespace DeliveryApplication.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> GetProducts()
        {
            using (ShopContext db = new ShopContext())
            {
                ViewBag.Products = await db.Products.ToListAsync();
            }

            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.ID = id;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Buy(Delivery delivery)
        {
            delivery.DateTime = DateTime.Now;

            using(ShopContext db = new ShopContext())
            {
                await Task.Run(() => db.Deliveries.Add(delivery));
                db.SaveChanges();
                ViewBag.Product = await db.Products.Where(t => t.ID == delivery.ProductID).FirstOrDefaultAsync();
            }
            ViewBag.Delivery = delivery;

            return View("CompletePurchase");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hello!!! There you can delivery any products! Welcome";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}