using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyLibrary.Services.API;
using ReinoTrebol.Web;
using ReinoTrebol.Web.Repositories;
using ReinoTrebol.Web.Utils.SweetAlert;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7263") })
    .AddScoped<IGenericRepository, GenericRepository>()
    .AddSweetAlert2()
    .AddScoped<ISweetAlertExtension, SweetAlertExtension>()
    .AddScoped<APIClient>();

await builder.Build().RunAsync();
