using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            return View(GetCart());
        }

        public void AddToCart(int id)
        {
            using (StoreContext db = new StoreContext())
            {
                Product prod = db.Products.FirstOrDefault(g => g.Id == id);
                if (prod != null)
                {
                    GetCart().AddItem(prod, 1);
                }
            };
        }

        public void ReduceFromCart(int id)
        {
            using (StoreContext db = new StoreContext())
            {
                Product prod = db.Products.FirstOrDefault(g => g.Id == id);
                if (prod != null)
                {
                    GetCart().ReduceAmount(id);
                }
            };
        }

        public void RemoveFromCart(int id)
        {
            using (StoreContext db = new StoreContext())
            {
                Product prod = db.Products.FirstOrDefault(g => g.Id == id);
                if (prod != null)
                {
                    GetCart().RemoveLine(id);
                }
            };
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}