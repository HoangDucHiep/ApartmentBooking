using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Bookify.Api.Extensions;

public static class OpenApiExtensions
{
    public static IServiceCollection AddOpenApi(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Bookify API",
                Version = "v1",
                Description = "API for apartment booking management",
                Contact = new OpenApiContact
                {
                    Name = "Support Team",
                    Email = "support@bookify.example.com"
                }
            });

            // Include XML comments
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        return services;
    }

    public static IApplicationBuilder MapOpenApi(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {

            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Bookify API v1");
            options.RoutePrefix = "swagger";

            // Remove the automatic redirect from root to Swagger UI
            options.ConfigObject.DisplayOperationId = false;
            options.ConfigObject.DefaultModelsExpandDepth = -1;
            options.ConfigObject.DefaultModelExpandDepth = 2;
            options.ConfigObject.DefaultModelRendering = Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Example;

            // Disable trying to serve index.html at the root
            options.DocumentTitle = "Bookify API Documentation";
        });

        return app;
    }
}