using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.API.Models;
using Dashboard.Interface;
using Dashboard.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Dashboard
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<SRM_DEVContext>(options => options.UseSqlServer(@"Data Source=172.16.0.161\sql2014_dev;Initial Catalog=SRM_DEV;Persist Security Info=True;User ID=sa;Password=P@$$w0rd"));
            services.AddScoped<TaskteamInterface, TaskteamService>();
            services.AddScoped<TeamSummaryInterface, TeamSummaryService>();
            services.AddScoped<IPieChart, PieChartService>();
            services.AddScoped<IPerson, PersonService>();
            services.AddScoped<IChartPerson, ChartPersonService>();
            services.AddScoped<IQuaterMonth, QuaterMonthService>();
            services.AddScoped<IQuater, QuaterService>();
            services.AddScoped<IRunningNo, RunningNoService>();
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
            app.UseCors("GMPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
