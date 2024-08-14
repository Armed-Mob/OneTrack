using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OT.Blazor;
using OT.Blazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7289") }); // OT.Api Base Url

builder.Services.AddScoped<VinLookupService>();
builder.Services.AddScoped<VehicleColorService>();
builder.Services.AddScoped<ShopService>();
builder.Services.AddScoped<ShopClientService>();

await builder.Build().RunAsync();


