using ShoppingApp.Business.Abstract;
using ShoppingApp.Data.Abstract;
using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Order order)
        {
            await _unitOfWork.Orders.CreateAsync(order);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<Order>> GetOrders(string userId=null)
        {
            return await _unitOfWork.Orders.GetOrders(userId);
        }
    }
}
