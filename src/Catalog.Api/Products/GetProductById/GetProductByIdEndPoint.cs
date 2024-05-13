
using Catalog.Api.Products.GetProductById;

namespace Catalog.Api.Products.GetProductById;
public record GetProdoctByIdResponse(Product Product);


public class GetProductByIdEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Products/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByIdQuery(id));
            var response = result.Adapt<GetProdoctByIdResponse>();
            return Results.Ok(response);
        })
            .WithName("GetProductById")
            .Produces<GetProdoctByIdResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("get Product id")
            .WithDescription("get  Product id ");
    }
}

