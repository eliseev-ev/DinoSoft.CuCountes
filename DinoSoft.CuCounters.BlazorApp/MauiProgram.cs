using DinoSoft.CuCounters.BlazorApp.Data;
using DinoSoft.CuCounters.Domain.Infrastructure;
using Microsoft.AspNetCore.Components.WebView.Maui;

namespace DinoSoft.CuCounters.BlazorApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .RegisterBlazorMauiWebView()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddBlazorWebView();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddSingleton<MainDataManager>();

            return builder.Build();
        }
    }
}