using BlazingCheckers.Client.Repositories;
using BlazingCheckers.Client.ViewModels;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazingCheckers.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient("BlazingCheckers.ServerAPI", 
                client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                 .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazingCheckers.ServerAPI"));
            builder.Services.AddApiAuthorization();

            builder.Services.AddScoped<ApiGamesRepository>();
            builder.Services.AddTransient<GameViewModel>();
            builder.Services.AddTransient<GamesViewModel>();

            await builder.Build().RunAsync();
        }
    }
}
