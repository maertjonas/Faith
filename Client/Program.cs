using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Faith.Client;
using Faith.Shared.Posts;
using Microsoft.AspNetCore.Components.Authorization;
using Faith.Client.Shared;
using Faith.Shared.Users;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, FakeAuthenticationProvider>();
await builder.Build().RunAsync();