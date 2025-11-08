using LatestEcommAPI.Database;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// this adds the controller services to the DI container
builder.Services.AddControllers();

// Swagger support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "LatestEcommAPI",
        Version = "v1"
    });
});

var app = builder.Build();

// enable Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "LatestEcommAPI v1");
});

// Map all controllers
app.MapControllers();

// run DB migrations if needed

DbController.Migrate();

app.Run();
