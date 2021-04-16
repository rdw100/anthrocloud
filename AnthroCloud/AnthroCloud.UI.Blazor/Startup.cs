using AnthroCloud.UI.Blazor.Services;
using Blazored.Modal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace AnthroCloud.UI.Blazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            string baseAddressPath;

            if (_env.IsProduction())
            {
                baseAddressPath = Configuration.GetValue<string>("ConfigurationSettings:baseProdApiAddressPath");
            }
            else
            {
                baseAddressPath = Configuration.GetValue<string>("ConfigurationSettings:baseApiAddressPath");
            }

            services.AddHttpClient<IAnthroService, AnthroService>(client =>
            {
                client.BaseAddress = new Uri(baseAddressPath);
            });

            services.AddHttpClient<IAnthroStatsService, AnthroStatsService>(client =>
            {
                client.BaseAddress = new Uri(baseAddressPath);
            });

            services.AddHttpClient<IChartService, ChartService>(client =>
            {
                client.BaseAddress = new Uri(baseAddressPath);
            });

            services.AddBlazoredModal();

            //services.AddServerSideBlazor()
            //    .AddCircuitOptions(option =>
            //    {
            //        option.DetailedErrors = true;
            //        //option.DisconnectedCircuitMaxRetained = 100;
            //        //option.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(3);
            //        //option.JSInteropDefaultCallTimeout = TimeSpan.FromMinutes(1);
            //        //option.MaxBufferedUnacknowledgedRenderBatches = 10;
            //    });

            //services.AddServerSideBlazor()
            //    .AddHubOptions(options =>
            //    {
            //        //options.ClientTimeoutInterval = TimeSpan.FromSeconds(30);
            //        options.EnableDetailedErrors = true;
            //        //options.HandshakeTimeout = TimeSpan.FromSeconds(15);
            //        //options.KeepAliveInterval = TimeSpan.FromSeconds(15);
            //        //options.MaximumParallelInvocationsPerClient = 1;
            //        //options.MaximumReceiveMessageSize = 32 * 1024;
            //        //options.StreamBufferCapacity = 10;
            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/GlobalError");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
