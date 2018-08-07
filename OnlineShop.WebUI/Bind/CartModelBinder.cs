using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Domain.Entities;

namespace OnlineShop.WebUI.Bind
{
    public class CartModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Cart cart = (Cart)controllerContext.HttpContext.Session[sessionkey];
            if(cart == null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session[sessionkey] = cart;
            }
            return cart;
        }
        private const string sessionkey = "Cart";
    }
}