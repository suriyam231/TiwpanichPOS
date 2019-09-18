using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RunningNo.API.Interfaces;
using RunningNo.API.Models;
using RunningNo.API.Services;
namespace RunningNo.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<SRM_DEVContext>(options => options.UseSqlServer(@"Data Source=172.16.0.161\sql2014_dev;Initial Catalog=SRM_DEV;Persist Security Info=True;User ID=sa;Password=P@$$w0rd"));
            services.AddScoped<ISRMContext, SRM_DEVContext>();
            services.AddScoped<IRunningNoService, RunningNoService>();
            services.AddScoped<IRunningTypeService,RunningTypeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            //For Origin Access
            app.UseCors("GMPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
