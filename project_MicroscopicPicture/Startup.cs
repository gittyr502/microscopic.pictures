using BL;
using DL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_MicroscopicPicture
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
            services.AddScoped<IRatingDL, RatingDL>();
            services.AddScoped<IRatingBL, RatingBL>();
            services.AddScoped<IUserBL, UserBL>();
            services.AddScoped<IExamBL, ExamBL>();
            services.AddScoped<IExamDL, ExamDL>();
            services.AddScoped<IUserDL, UserDL>();
            services.AddScoped<IPicturesBL, PicturesBL>();
            services.AddScoped<IPicturesDL, PicturesDL>();
            services.AddScoped<IPatientBL, PatientBL>();
            services.AddScoped<IPatientDL, PatientDL>();
         
            services.AddScoped<IPicturesBL, PicturesBL>();
            services.AddScoped<IPicturesDL, PicturesDL>();

            services.AddDbContext<MicroscopicPicture1Context>(options => options.UseSqlServer("Server=srv2\\pupils;Database=MicroscopicPicture1;Trusted_Connection=True;"),ServiceLifetime.Scoped);
            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "project_MicroscopicPicture", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "project_MicroscopicPicture v1"));
            }
            app.UseMiddleware();
            app.UseMiddleware1();
            app.UseHttpsRedirection();

            app.UseRouting();
             app.Map("/api", (app1) =>
            {
                app1.UseRouting();
                app1.UseAuthorization();
                app1.UseEndpoints(endpoints => endpoints.MapControllers());
            });
             app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
