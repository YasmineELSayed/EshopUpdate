
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.Api.Data;

    public class CachedRepository(IBasketRepository repository,IDistributedCache cache )
        : IBasketRepository
    {

        public async Task<ShopCart> GetBasket(string userName, CancellationToken cancellationToken = default)
        {
            var cachedBasket = await cache.GetStringAsync(userName, cancellationToken);

            if (!string.IsNullOrEmpty(cachedBasket))
               return   JsonSerializer.Deserialize<ShopCart>(cachedBasket)!;

            var basket= await repository.GetBasket(userName, cancellationToken);
          
            
            await cache.SetStringAsync(userName, JsonSerializer.Serialize(basket));
      
            return basket;

        }


        public  async Task<ShopCart> StoreBasket(ShopCart basket, CancellationToken cancellationToken = default)
        {
            
        await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket), cancellationToken);



        return basket;
    }



        public  async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
        {
          

           await repository.DeleteBasket(userName, cancellationToken);

          await cache.RemoveAsync(userName, cancellationToken);

         return true;
    }

       

       
    }

