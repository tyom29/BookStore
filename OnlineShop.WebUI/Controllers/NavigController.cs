using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Domain.Abstract;

namespace OnlineShop.WebUI.Controllers
{
    public class NavigController : Controller
    {
        // GET: Navig
        IProductRepository repository;
        public NavigController(IProductRepository rp)
        {
            repository = rp;
        }
        public PartialViewResult Menu(string category=null)
        {
            ViewBag.SelectedCategory = category;
            string[] result = (repository.Products.Select(x => x.Category).Distinct().Select(x=>x)).ToArray();
            return PartialView(result);
        }
    }
}