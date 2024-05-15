
namespace Basket.Api.basket.GetBasket;


    public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShopCart Cart);
    public class GetBasketHandler
           : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public  async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
        //TODO: Get Basket from database
        // var basket=await_repository.GetBasket(request.UserName);

        return  new GetBasketResult(new ShopCart("swn"));
        }
    }

