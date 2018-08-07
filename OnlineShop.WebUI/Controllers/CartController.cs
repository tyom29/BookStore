using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Domain.Abstract;
using OnlineShop.Domain.Entities;
using OnlineShop.WebUI.Models;

namespace OnlineShop.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        // GET: Cart

        public CartController(IProductRepository rp)
        {
            repository = rp;
        }
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if(cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public RedirectToRouteResult AddCart(Cart cart,int productID, string returnURL)
        {
            Product prod = repository.Products.FirstOrDefault(p=>p.ProductID==productID);
            if(prod!=null)
            {
                cart.Add(prod, 1);
            }
            return RedirectToAction("Index", new { returnURL });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int productID, string returnURL)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productID);
            if (prod != null)
            {
                cart.RemoveLine(prod);
            }
            return RedirectToAction("Index", new { returnURL });
        }
        public ViewResult Index(Cart cart, string returnURL)
        {
            return View(new CartIndexViewModel { ReturnURL = returnURL, Cart = cart });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public ViewResult Checkout(SheepingDetails details)
        {
            return View(details);
        }
    }
}