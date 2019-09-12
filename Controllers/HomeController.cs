using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    [Authorize]
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (StoreContext db = new StoreContext())
            {
                return View(db.Products.ToList());
            }

        }

        public ActionResult CategoryProducts(string category)
        {
            List<Product> result = new List<Product>();

            using (StoreContext db = new StoreContext())
            {
                result = db.Products.Where(c => c.Category.ToLower() == category.ToLower()).ToList();
            }
            return View("Index", result);
        }

        [AllowAnonymous]
        public JsonResult GetProductsJson()
        {
            using (StoreContext db = new StoreContext())
            {
                var list = db.Products.Where(t => t.Image != null).ToList();
                foreach (var item in list)
                {
                    item.Image = null;
                }
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [AllowAnonymous]
        public ActionResult TableJson()
        {
            return View();
        }
    }
}