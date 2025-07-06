using Microsoft.Extensions.DependencyInjection; // Explicitly import the namespace for Microsoft.Extensions.DependencyInjection.OpenApiServiceCollectionExtensions
using Bookify.Api.Extensions;
using Bookify.Application;
using Bookify.Infrastructure; // Explicitly import the namespace for Bookify.Api.Extensions

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Resolve ambiguity by explicitly specifying the namespace for AddOpenApi
OpenApiExtensions.AddOpenApi(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.ApplyMigration();
    //app.SeedData(); // Seed the database with initial data
}

app.UseHttpsRedirection();

// a test get endpoint
app.MapGet("/", () =>
{
    // This prevents automatic redirect to /index.html
    return "Welcome to Bookify API! API documentation is available at /swagger";
});
app.MapControllers();

app.Run();
