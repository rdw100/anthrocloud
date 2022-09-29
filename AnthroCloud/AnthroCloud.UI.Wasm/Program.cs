using AnthroCloud.UI.Wasm;
using AnthroCloud.UI.Wasm.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
string baseAddressPath = builder.Configuration.GetValue<string>("ConfigurationSettings:baseApiAddressPath");

builder.Services.AddHttpClient<IPatientService, PatientService>(client =>
{
    client.BaseAddress = new Uri(baseAddressPath);
});

await builder.Build().RunAsync();
