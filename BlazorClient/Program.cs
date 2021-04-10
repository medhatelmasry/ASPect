using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            string API_URL;
            if (builder.HostEnvironment.IsDevelopment()) {
                API_URL = Constants.API.DEV_URL;
            } else {
                API_URL = Constants.API.PRODUCTION_URL;
            }
            
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(API_URL) });

            await builder.Build().RunAsync();
        }
    }
}
