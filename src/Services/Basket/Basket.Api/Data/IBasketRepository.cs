namespace Basket.Api.Data
{
    public interface IBasketRepository
    {
        Task<ShopCart> GetBasket(string userName, CancellationToken cancellationToken = default);
        Task<ShopCart> StoreBasket(ShopCart basket, CancellationToken cancellationToken = default);
        Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default);
    }
}
