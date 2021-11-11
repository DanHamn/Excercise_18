using Excercice_17_Maskinpark.Core.Services;
using Excercice_17_Maskinpark.Data.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Excercice_17_Maskinpark.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient<IMachineDataService, MachineDataService>(client =>
            {
                //client.BaseAddress = new Uri("https://localhost:44359/");//Local Api.
                client.BaseAddress = new Uri("https://maskinparkapi.azurewebsites.net");//Azure hosted Api
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            await builder.Build().RunAsync();
        }
    }
}
