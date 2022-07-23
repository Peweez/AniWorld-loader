using CleanArchTemplate.Core.Http;
using CleanArchTemplate.Infrastructure.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchTemplate.Extensions;

public static class HttpClientExtension
{
    public static void AddHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient<IHttpRequestSender, HttpRequestSender>();
    }
}