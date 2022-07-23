using CleanArchTemplate.Core.Http;
using CleanArchTemplate.Core.Services.Customer;
using CleanArchTemplate.Infrastructure.Http;
using CleanArchTemplate.Shared.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchTemplate.Extensions;

public static class DependencieInjectionExtension
{
    public static void AddDependencieInjections(this IServiceCollection services)
    {
        services.AddSingleton<IProblemDetailsHelper, ProblemDetailsHelper>()
            .AddScoped<IHttpRequestSender, HttpRequestSender>()
            .AddScoped<ICustomerService, CustomerService>();
    }
}