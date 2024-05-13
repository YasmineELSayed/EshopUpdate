﻿
using Catalog.Api.Products.UpdateProduct;

namespace Catalog.Api.Products.DeleteProduct;
public record DeleteProductCommand(Guid Id): ICommand<DeleteProductResult>;
public record DeleteProductResult(bool IsSuccess);



internal class DeleteProductHandler
(IDocumentSession session, ILogger<UpdateProductCommandHandler> logger)
: ICommandHandler<DeleteProductCommand, DeleteProductResult>

{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductByCategoryHandler.Handle called with {@command}", command);
        session.Delete<Product>(command.Id);
        await session.SaveChangesAsync(cancellationToken);
        return new DeleteProductResult(true);

    }
}

