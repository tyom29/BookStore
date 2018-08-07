using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Abstract
{
    public interface IOrderProcesore
    {
        void ProceseOrder(Cart cart, SheepingDetails details);
    }
}
