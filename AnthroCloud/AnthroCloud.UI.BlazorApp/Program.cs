using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using AnthroCloud.UI.BlazorApp.Services;
using Blazored.Modal;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllersWithViews();

string baseAddressPath = builder.Configuration.GetValue<string>("ConfigurationSettings:baseApiAddressPath");

builder.Services.AddHttpClient<IAnthroService, AnthroService>(client =>
{
    client.BaseAddress = new Uri(baseAddressPath);
});

builder.Services.AddHttpClient<IAnthroStatsService, AnthroStatsService>(client =>
{
    client.BaseAddress = new Uri(baseAddressPath);
});

builder.Services.AddHttpClient<IChartService, ChartService>(client =>
{
    client.BaseAddress = new Uri(baseAddressPath);
});

builder.Services.AddBlazoredModal();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStatusCodePages();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
