using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Domain.Entities;

namespace OnlineShop.WebUI.Models
{
    public class ProductListPageInfoToView
    {
        public IEnumerable<Product> Products { set; get; }
        public PageInfo PageInfo { set; get; }
        public string Category { set; get; }
    }
}