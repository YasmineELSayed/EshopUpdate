using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);
//add  services to the container 
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
.AddApiServices();
    


var app = builder.Build();


// Configure the HTTP request pipeline.
app.useApiServices();

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}
app.Run();
