using AnthroCloud.UI.Blazor.Services;
using Blazored.Modal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

// Configure the HTTP request pipeline.
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