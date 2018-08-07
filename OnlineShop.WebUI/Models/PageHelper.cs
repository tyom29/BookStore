using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace OnlineShop.WebUI.Models
{
    public static class PageHelper
    {
        public static MvcHtmlString PageLink(this HtmlHelper helper,PageInfo pInfo,Func<int,string> func)
        {
            StringBuilder result = new StringBuilder();
            for(int i=1; i<=pInfo.TotalPage(); i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", func(i));
                tag.InnerHtml = i.ToString();
                if(pInfo.CurrentPage==i)
                {
                   tag.AddCssClass("Selected");
                }
                
                result.Append(tag.ToString()+" ");
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}