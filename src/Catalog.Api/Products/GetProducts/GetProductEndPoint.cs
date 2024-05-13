
using Catalog.Api.Products.GetProducts;
using static FastExpressionCompiler.ExpressionCompiler;

namespace Catalog.Api.Products.GetProducts;
public record  GetProductsResponse(IEnumerable<Product>Products);

public class GetProductEndPoint : ICarterModule
{
    public async void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Products", async (ISender sender) =>
        {
            var result = await sender.Send(new GetProductsQuery());

            var response = result.Adapt<GetProductsResponse>();
            return Results.Ok(response);
        })
            .WithName("Get products")
            .Produces<GetProductsResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product")
            .WithDescription("Get Product ");


    }
}

