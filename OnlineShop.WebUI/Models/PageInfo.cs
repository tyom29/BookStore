using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.WebUI.Models
{
    public class PageInfo
    {
        public int CurrentPage { set; get; }
        public int TotalItems { set; get; }
        public int ItemsPerPage { set; get; }
        public int TotalPage()
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        }
    }
}