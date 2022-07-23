using CleanArchTemplate.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchTemplate.Extensions;

public static class ControllerExtension
{
    public static void AddControllerConfigurations(this IServiceCollection services)
    {
        services.AddControllers().AddDataAnnotationsLocalization(options =>
        {
            options.DataAnnotationLocalizerProvider = (type, factory) =>
                factory.Create(typeof(SharedResource));
        });
    }
}