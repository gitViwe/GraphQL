using Client;
using Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://api.spacex.land/") });

builder.Services.AddHttpClient<ISpaceXDataService, RESTSpaceXDataService>
                (spds => spds.BaseAddress = new Uri("https://api.spacex.land/"));

await builder.Build().RunAsync();
