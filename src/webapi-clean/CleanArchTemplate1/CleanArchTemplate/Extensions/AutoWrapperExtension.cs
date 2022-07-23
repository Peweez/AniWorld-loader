using AutoWrapper;
using Microsoft.AspNetCore.Builder;

namespace CleanArchTemplate.Extensions;

public static class AutoWrapperExtension
{
    public static void UseAutoWrapperWithConfigurations(this IApplicationBuilder app)
    {
        app.UseApiResponseAndExceptionWrapper(GetAutowrapperOptions());
    }

    private static AutoWrapperOptions GetAutowrapperOptions()
    {
        return new AutoWrapperOptions { UseApiProblemDetailsException = true, IgnoreWrapForOkRequests = true, EnableExceptionLogging = false, EnableResponseLogging = false };
    }
}