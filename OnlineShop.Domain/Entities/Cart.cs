using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public void Add(Product prod, int count)
        {
            CartLine line = lineCollection.Where(x => x.Product.ProductID == prod.ProductID).FirstOrDefault();
            if(line==null)
            {
                lineCollection.Add(new CartLine { Product = prod, Quantity = count });
            }
            else
            {
                line.Quantity += count;
            }
        }
        public void RemoveLine(Product p)
        {
            lineCollection.RemoveAll(e => e.Product.ProductID == p.ProductID);
        }
       public decimal TotalCoast()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
        public IEnumerable<CartLine> Lines
        {
            get => lineCollection;
        }
    }
    public class CartLine
    {
        public Product Product { set; get; }
        public int Quantity { set; get; }
    }
}
