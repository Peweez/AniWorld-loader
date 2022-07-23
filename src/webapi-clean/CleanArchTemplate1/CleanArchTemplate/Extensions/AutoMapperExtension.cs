using CleanArchTemplate.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchTemplate.Extensions;

public static class AutoMapperExtension
{
    public static void AddAutoMapperConfigurations(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(CustomerMappingProfile));
    }
}