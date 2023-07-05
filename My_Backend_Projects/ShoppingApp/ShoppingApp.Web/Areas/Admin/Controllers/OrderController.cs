using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Business.Abstract;
using ShoppingApp.Entity.Concrete.Identity;
using ShoppingApp.Web.Models.Dtos;

namespace ShoppingApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderManager;
        private readonly UserManager<User> _userManager;

        public OrderController(IOrderService orderManager, UserManager<User> userManager)
        {
            _orderManager = orderManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderManager.GetOrders();
            List<OrderListDto> orderListDtos = new List<OrderListDto>();
            OrderListDto orderListDto;
            foreach (var order in orders)
            {
                orderListDto = new OrderListDto
                {
                    OrderId=order.Id,
                    OrderNumber=order.OrderNumber,
                    OrderDate=order.OrderDate,
                    FirstName=order.FirstName,
                    LastName=order.LastName,
                    Address=order.Address,
                    City=order.City,
                    Phone=order.Phone,
                    Email=order.Email,
                    OrderState=order.OrderState,
                    OrderType=order.OrderType,
                    OrderListItems=order.OrderItems.Select(oi=>new OrderListItemDto
                    {
                        OrderListItemId=oi.Id,
                        ProductName=oi.Product.Name,
                        Price=oi.Price,
                        Quantity=oi.Quantity,
                        ProductUrl=oi.Product.Url,
                        ImageUrl=oi.Product.ImageUrl
                    }).ToList()
                };
                orderListDtos.Add(orderListDto);
            }
            ViewBag.Title = "Tüm Siparişler";
            return View(orderListDtos);
        }
    }
}
