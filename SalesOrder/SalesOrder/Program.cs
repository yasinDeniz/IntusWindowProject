using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SalesOrder;
using SalesOrder.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

    builder.Services.AddHttpClient<ApiService>(client =>
    {
        client.BaseAddress = new Uri("http://localhost:5010/api/Orders/GetOrders");/*DatabaseAPI Uri*/
    });

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
