var builder = WebApplication.CreateBuilder(args);
//Add Servieces to the container

var app = builder.Build();

//configure http pipeline
app.Run();
