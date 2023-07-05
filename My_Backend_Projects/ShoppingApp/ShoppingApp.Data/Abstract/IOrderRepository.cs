using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Abstract
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetOrders(string userId = null);
    }
}
