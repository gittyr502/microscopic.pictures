using BL;
using DL;
using Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            services.AddCors(options => 
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                     .AllowAnyMethod();
                     
                     
            }));

            //services.AddMvc(options => options.EnableEndpointRouting = false);
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
            services.AddScoped<IPasswordHashHelper, PasswordHashHelper>();
            services.AddScoped<IPicturesBL, PicturesBL>();
            services.AddScoped<IPicturesDL, PicturesDL>();
            services.AddAutoMapper(typeof(Startup));


            services.AddDbContext<MicroscopicPicture1Context>(options => options.UseSqlServer("Server=DESKTOP-45L6QC9;Database=MicroscopicPicture1;Trusted_Connection=True;"), ServiceLifetime.Scoped);
            services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNameCaseInsensitive = true) ;
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("key").Value);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {

                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "project_MicroscopicPicture", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });
            services.AddResponseCaching();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
           
            app.UseErrorMiddleware();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "project_MicroscopicPicture v1"));
            }

           app.UseRatingMiddleware();
            app.UseResponseCaching();

            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                {
                    Public = true,
                    MaxAge = TimeSpan.FromSeconds(60)
                };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };
                await next();
            });
           app.UseCors("AllowAll");
            
            app.UseHttpsRedirection();
            app.UseAuthentication();
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
