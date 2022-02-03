using DinoSoft.CuCounters.BlazorApp.Data;
using DinoSoft.CuCounters.BlazorApp.Infrastructure;
using DinoSoft.CuCounters.Data.Infrastructure;
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
            builder.Services.AddSingleton<DataService>();

            return builder.Build();
        }
    }
}