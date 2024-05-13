
namespace Catalog.Api.Products.CreateProduct 
{
    public record CreateProductCommand(string Name,List<string>Category,String Description,string ImageFile,decimal Price)
    :ICommand<CreateProductResult>;
        public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler(IDocumentSession session)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public  async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {


            // Create Product Entity from command object
            //save to database
            //Return  Create Product Result 
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            //todo
            //save to database
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            //return result to the client
            return new CreateProductResult(product.Id);



        }
    }
}
