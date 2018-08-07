using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.Entity;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Concrete
{
    public class EFDbContext:DbContext
    {
        public DbSet<Product> Products { set; get; }
    }
}
