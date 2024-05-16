

namespace Basket.Api.Data
{
    public class BasketRepository (IDocumentSession session )
        : IBasketRepository
    {
       

        public async  Task<ShopCart> GetBasket(string userName, CancellationToken cancellationToken = default)
        {
            var basket = await session.LoadAsync<ShopCart>(userName, cancellationToken);

            return basket is null ? throw new BasketNotFoundException(userName) : basket;
        }

        public  async Task<ShopCart> StoreBasket(ShopCart basket, CancellationToken cancellationToken = default)
        {
            session.Store(basket);
            await session.SaveChangesAsync(cancellationToken);
            return basket;
        }

        public  async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
        {
            session.Delete<ShopCart>(userName);
            await session.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
