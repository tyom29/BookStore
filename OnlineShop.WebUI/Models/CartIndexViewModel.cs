using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Domain.Entities;

namespace OnlineShop.WebUI.Models
{
    public class CartIndexViewModel
    {
        public string ReturnURL { set; get; }
        public Cart Cart { set; get; }
    }
}