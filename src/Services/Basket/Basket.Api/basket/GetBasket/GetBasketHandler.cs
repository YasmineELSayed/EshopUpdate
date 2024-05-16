
using Basket.Api.Data;

namespace Basket.Api.basket.GetBasket;


    public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShopCart Cart);
    public class GetBasketHandler(IBasketRepository repository)
           : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public  async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
        //TODO: Get Basket from database
         var basket=await repository.GetBasket(query.UserName);

        return new GetBasketResult(basket);
        }
    }

