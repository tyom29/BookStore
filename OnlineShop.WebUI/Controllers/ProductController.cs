using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Domain.Abstract;
using OnlineShop.WebUI.Models;

namespace OnlineShop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        // GET: Product
        public ViewResult List(string category,int page=1)
        {
            ProductListPageInfoToView model = new ProductListPageInfoToView
            {
                Products = repository.Products.Select(x => x).Where(x => category == null || x.Category == category).OrderBy(e => e.ProductID).Skip((page - 1) * pageSize).Take(pageSize),
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = (category != null) ? repository.Products.Select(x => x).Where(x => x.Category == category).Count()
                    : repository.Products.Select(x => x).Count()
                    
                },
                Category=category
            };
            return View(model);
        }
        public ProductController(IProductRepository rp)
        {
            repository = rp;
        }
        public int pageSize = 4;
    }
}