using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Refit;
using BookUI.DataAccess;

//https://localhost:44312/api

namespace BookUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddRefitClient<IBookData>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(uriString: "https://localhost:44312/api");
            });


            await builder.Build().RunAsync();
        }
    }
}
