using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using ExpensesApp.Client.HttpUtils;

namespace ExpensesApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient(
                "ExpensesApp.ServerAPI", 
                client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            ).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
            
            builder.Services.AddHttpClient<PublicHttpClient>(
                client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) 
            );
            
            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ExpensesApp.ServerAPI"));

            builder.Services.AddApiAuthorization();

            await builder.Build().RunAsync();
        }
    }
}
