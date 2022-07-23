using Microsoft.AspNetCore.Builder;

namespace CleanArchTemplate.Extensions;

public static class LocalizationExtension
{
    public static void UseCustomRequestLocalization(this IApplicationBuilder app)
    {
        app.UseRequestLocalization(GetLocalizationOptions());
    }
    private static RequestLocalizationOptions GetLocalizationOptions()
    {
        string[] supportedCultures = new[] { "hy", "en", "ru" };
        RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures);
        return localizationOptions;
    }
}