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
                return View(await db.Products.ToListAsync());
            }

            
        }

        [HttpGet]
        public ActionResult Buy(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = id;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Buy(Delivery delivery)
        {
            if(delivery == null)
            {
                return HttpNotFound();
            }
            delivery.DateTime = DateTime.Now;

            using(ShopContext db = new ShopContext())
            {
                await Task.Run(() => db.Deliveries.Add(delivery));
                await db.SaveChangesAsync();
                ViewBag.Product = await db.Products.Where(t => t.ID == delivery.ProductID).FirstOrDefaultAsync();
            }
            ViewBag.Delivery = delivery;

            return View("CompletePurchase");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            using (ShopContext db = new ShopContext())
            {
                await Task.Run(() => db.Products.Add(product));
                await db.SaveChangesAsync();
            }

            return RedirectToAction("GetProducts");
        }

        [HttpGet]
        public async Task<ActionResult> EditProduct(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            Product product;

            using (ShopContext db = new ShopContext())
            {
                product = await db.Products.FindAsync(id);

                if(product == null)
                {
                    return HttpNotFound();
                }
            }

            return View(product);
        }

        [HttpPost]
        public async Task<ActionResult> EditProduct(Product product)
        {
            if(product == null)
            {
                return HttpNotFound();
            }

            using (ShopContext db = new ShopContext())
            {
                db.Entry(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }

            return RedirectToAction("GetProducts");
        }

        public async Task<ActionResult> DeleteProduct(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }

            using (ShopContext db = new ShopContext())
            {
                Product product = await db.Products.FindAsync(id);
                
                if(product != null)
                {
                    await Task.Run(() => db.Products.Remove(product));
                    await db.SaveChangesAsync();
                }
                else
                {
                    return HttpNotFound();
                }
            }

            return RedirectToAction("GetProducts");
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