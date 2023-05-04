using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MONSTER;
using MONSTER.Services;
using MudBlazor.Services;
using Microsoft.Extensions.Configuration;
using MONSTER.Models;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage(config =>
       config.JsonSerializerOptions.WriteIndented = true
   );
builder.Services.AddScoped<ChatService>();



await builder.Build().RunAsync();
