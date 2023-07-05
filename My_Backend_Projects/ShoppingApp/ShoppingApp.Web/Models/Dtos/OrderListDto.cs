using ShoppingApp.Entity.Concrete;

namespace ShoppingApp.Web.Models.Dtos
{
    public class OrderListDto
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public EnumOrderState OrderState { get; set; }
        public EnumOrderType OrderType { get; set; }
        public List<OrderListItemDto> OrderListItems { get; set; }
        public decimal? TotalPrice()
        {
            return OrderListItems.Sum(oli=>oli.Price * oli.Quantity);
        }
    }

    public class OrderListItemDto
    {
        public int OrderListItemId { get; set; }
        public decimal? Price { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public string ProductUrl { get; set; }
    }
}
