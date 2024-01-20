using BlazorAuthentication;
using BlazorAuthentication.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.ComponentModel.Design;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiBaseAddress = builder.Configuration.GetValue<string>("APIBaseAddress");

if (string.IsNullOrWhiteSpace(apiBaseAddress))
{
    throw new InvalidOperationException("API Base Address отсутствует в файле appsettings.");
}


builder.Services.AddScoped<ITokenService, TokenService>();

//added Microsoft.Extensions.Http in NuGet
builder.Services.AddHttpClient<AuthenticationHttpClient>(client =>
{
	client.BaseAddress = new Uri(apiBaseAddress);
});



await builder.Build().RunAsync();
