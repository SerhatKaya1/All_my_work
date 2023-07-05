namespace ShoppingApp.Web.Models.Dtos
{
    public class CardDto
    {
        public int CardId { get; set; }
        public List<CardItemDto> CardItems { get; set; }
        public decimal? TotalPrice()
        {
            return CardItems.Sum(ci => ci.ItemPrice * ci.Quantity);
        }
    }
    public class CardItemDto
    {
        public int CardItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductUrl { get; set; }
        public decimal? ItemPrice { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
    }
}
