using JoinUs.API.Interface;
using JoinUs.API.Service;
using ListInteresting.API.Interface;
using ListInteresting.API.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ListApplicant.API.Interface;
using ListApplicant.API.Service;
using ListInterviewerResult.API.Interface;
using ListInterviewerResult.API.Service;
using AssessmentByPM.API.Interface;
using AssessmentByPM.API.Service;
using DashboardHr.API.Service;
using DashboardHr.API.Interface;
using RegisterManange.API.Models;
using ListStatusJob.API.Interface;
using ListStatusJob.API.Service;
using ListOfValue.API.Interface;
using ListOfValue.API.Service;
using Agreement.API.Interface;
using Agreement.API.Service;
using Exam.API.Service;
using Exam.API.Interface;
using ApplicantExamAnswer.API.Interface;
using ApplicantExamAnswer.API.Service;

namespace JoinUs.API
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
            services.AddDbContext<SRM_DEVContext>(options => options.UseSqlServer(@"Data Source=172.16.0.249;Initial Catalog=SRM_DEV;Persist Security Info=True;User ID=sa;Password=p@ssw0rd"));
            services.AddScoped<JoinUsInterface, JoinUsService>();
            services.AddScoped<ListInterestingInterface, ListInterestingService>();
            services.AddScoped<ListApplicantsInterface, ListApplicantService>();
            services.AddScoped<IListInterviewerResultInterface, ListInterviewerResultService>();
            services.AddScoped<AssessmentInterface, AssessmentService>();
            services.AddScoped<DashboardHrInterface, DashboardHrService>();
            services.AddScoped<ListStatusJobInterface, ListStatusJobService>();
            services.AddScoped<ListOfValueInterface, ListOfValueService>();
            services.AddScoped<AgreementInterface, AgreementService>();
            services.AddScoped<DBExamInterface, DBExamService>();
            services.AddScoped<ApplicantExamAnswerHistoryInterface, ApplicantExamAnswerHistoryService>();
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
