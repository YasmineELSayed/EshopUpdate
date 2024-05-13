
using Catalog.Api.Products.GetProductById;

namespace Catalog.Api.Products.DeleteProduct;
public record DeleteProductResponse(bool IsSuccess);


public class DeleteProductEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/Products/{id}", async (Guid id, ISender sender) =>
        {

            var result = await sender.Send(new DeleteProductCommand(id));
            var response = result.Adapt<DeleteProductResponse>();
            return Results.Ok(response);



        })
         .WithName("DeleteProduct")
            .Produces<DeleteProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("delete Product ")
            .WithDescription("delete  Product  ");
    }
}


