using AnthroCloud.UI.Wasm;
using AnthroCloud.UI.Wasm.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

string patientApiPath = builder.Configuration.GetValue<string>("ConfigurationSettings:patientApiPath");
string visitApiPath = builder.Configuration.GetValue<string>("ConfigurationSettings:visitApiPath");
string statApiPath = builder.Configuration.GetValue<string>("ConfigurationSettings:statApiPath");

builder.Services.AddHttpClient<IPatientService, PatientService>(client =>
{
    client.BaseAddress = new Uri(patientApiPath);
});
builder.Services.AddHttpClient<IVisitService, VisitService>(client =>
{
    client.BaseAddress = new Uri(visitApiPath);
});
builder.Services.AddHttpClient<IAnthroStatsService, AnthroStatsService>(client =>
{
    client.BaseAddress = new Uri(statApiPath);
});


await builder.Build().RunAsync();
