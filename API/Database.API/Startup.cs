using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.API.Interface;
using Database.API.Models;
using Database.API.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Database.API
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
            services.AddCors(x => x.AddPolicy("GMPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            }));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<SRM_DEVContext>(options => options.UseSqlServer
            //(@"Data Source=databasetiwpanich.database.windows.net Catalog=Tiwpanich;Persist Security Info=True;User ID=ppap;Password=0944353673Pab"));
            (@"Server = tcp:databasetiwpanich.database.windows.net,1433; Initial Catalog = Tiwpanich; Persist Security Info = False; 
            User ID = ppap; Password =0944353673Pab; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False;"));
            services.AddScoped<DBBranchInterface, DBBranchService>();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("GMPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
