using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using FullStack.App.Services;
using FullStack.Client;
using System;

namespace FullStack.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Since Blazor is running on the server, we can use an application service
            // to read the forecast data.
            services.AddSingleton<WeatherForecastService>();
            services.AddHttpClient<ValuesClient>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://localhost:44324");
                httpClient.Timeout = TimeSpan.FromMinutes(1);
            });
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
