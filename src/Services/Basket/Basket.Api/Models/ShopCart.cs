namespace Basket.Api.Models
{
    public class ShopCart
    {

        public string UserName { get; set; } = default!;
        public List<ShoppingCartItem> Items { get; set; } = new();
        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

        public ShopCart(string userName)
        {
            UserName = userName;
        }

        //Required for Mapping
        public ShopCart()
        {
        }
    }
}
