using AnthroCloud.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;

namespace AnthroCloud.API
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
        public void ConfigureServices(IServiceCollection services)
        {
            //if (_env.IsProduction())
            //{
                String connection = Configuration.GetConnectionString("AnthroCloudDatabaseMySql");

                services.AddDbContext<AnthroCloudContextMySql>(options =>
                   options.UseMySql(connection, 
                                    new MySqlServerVersion(new Version(5, 7, 29)),
                                    mySqlOptions => mySqlOptions
                                        .CharSetBehavior(CharSetBehavior.NeverAppend)
                                    ));
            //}
            //else
            //{
            //    String connection = Configuration.GetConnectionString("AnthroCloudDatabaseMsSql");

            //    services.AddDbContext<AnthroCloudContextMsSql>(options =>
            //        options.UseSqlServer(connection));
            //}

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
