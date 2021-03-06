using DinoSoft.CuCounters.BlazorApp.Infrastructure;
using DinoSoft.CuCounters.Data;
using DinoSoft.CuCounters.Data.Infrastructure;
using DinoSoft.CuCounters.Data.Repository;
using DinoSoft.CuCounters.Domain;
using DinoSoft.CuCounters.Domain.Infrastructure;
using DinoSoft.CuCounters.Modularity.Extension;
using Microsoft.AspNetCore.Components.WebView.Maui;

namespace DinoSoft.CuCounters.BlazorApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            // Infrastructure
            builder.Services.AddScoped<NavigationService>();

            // Modules

            builder.Services.RegisterModule(new DataModule());
            builder.Services.RegisterModule(new DomainModule());

            return builder.Build();
        }
    }
}