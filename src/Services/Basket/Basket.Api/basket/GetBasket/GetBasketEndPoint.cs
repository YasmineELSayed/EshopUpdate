using Basket.Api.Models;

using Microsoft.AspNetCore.Hosting.Server;

namespace Basket.Api.basket.GetBasket;

    public class GetBasketEndPoint
    {

        public record GetBasketResponse(ShopCart Cart);

        public class GetBasketEndpoints : ICarterModule
        {
            public void AddRoutes(IEndpointRouteBuilder app)
            {
                app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
                {
                    var result = await sender.Send(new GetBasketQuery(userName));

                    var respose = result.Adapt<GetBasketResponse>();

                    return Results.Ok(respose);
                })
                .WithName("GetProductById")
                .Produces<GetBasketResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Product By Id")
                .WithDescription("Get Product By Id");
            }
        }
    }

