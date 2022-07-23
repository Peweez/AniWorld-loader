using CleanArchTemplate.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CleanArchTemplate.Extensions;

public static class SwaggerConfigurationExtension
{
    public static void AddSwaggerConfigurations(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "CleanArchTemplate API",
                License = new OpenApiLicense
                {
                    Name = "ԱԿԲԱ",
                    Url = new Uri("https://www.acba.am")
                }
            });
            options.OperationFilter<SwaggerHeaders>();
            string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            IncludeXmlComments(options);
        });
    }
    public static void UseSwaggerConfigurations(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchTemplate v1");
            options.InjectStylesheet("/swagger-ui/custom-swagger-ui.css");
        });
    }
    private static void IncludeXmlComments(SwaggerGenOptions options)
    {
        List<string> projectNames = new()
        {
            string.Empty,
            nameof(Core),
            nameof(Infrastructure)
        };
        foreach (string projectName in projectNames)
        {
            string xmlPath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}{(string.IsNullOrEmpty(projectName) ? string.Empty : "." + projectName)}.xml");
            options.IncludeXmlComments(xmlPath);
        }
    }
}