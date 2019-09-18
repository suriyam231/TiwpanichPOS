using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auther.API.Interfaces;
using Auther.API.Models;
using Auther.API.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Auther.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void DefineService(IServiceCollection services)
        {
            services.AddDbContext<SRMContext>(options => options.UseSqlServer(System.ConnectString));
            services.AddScoped<ISRMContext, SRMContext>();
            services.AddScoped<IAutherService, AutherService>();
            services.AddScoped<ILDAPService, LDAPService>();
            services.AddScoped<IRunningNoService, RunningNoService>();
            services.AddScoped<IEncryptionService, EncryptionService>();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            this.DefineService(services);
            //For Origin Access
            services.AddCors(x => x.AddPolicy("SRMPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            if (env.IsProduction() || env.IsStaging() || env.IsEnvironment("Staging_2"))
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            //For Origin Access
            app.UseCors("SRMPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
