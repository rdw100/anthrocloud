using AnthroCloud.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddDbContext<AnthroCloudContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AnthroCloudDatabaseMsSql")
        ));

builder.Services.AddDbContext<AssessmentContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AnthroCloudDatabaseMsSql")
        ));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();           
            //.WithOrigins("https://localhost:7234")
            //.AllowAnyMethod()
            //.WithHeaders(HeaderNames.ContentType);
    });
});
//options.UseMySql(builder.Configuration.GetConnectionString("AnthroCloudDatabaseMySql"),
//    new MySqlServerVersion(new Version(5, 7, 29)),
//    mySqlOptions => mySqlOptions
//        .CharSetBehavior(CharSetBehavior.NeverAppend)
//    ));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseWebAssemblyDebugging();
    //app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
} 
else 
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

//app.UseAuthorization();

app.UseCors();

app.MapRazorPages();

app.Run();