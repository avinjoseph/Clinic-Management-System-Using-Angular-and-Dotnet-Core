using Clinic_Management_System_8.Models;
using Clinic_Management_System_8.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System_8
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
            services.AddControllers();

            //--- add dependency injection for CMSDBContext ---//
            services.AddDbContext<CMSContext>(
                item => item.UseSqlServer(Configuration.GetConnectionString("ConStr"))
                );

            //--- add dependency injection ---//
            services.AddScoped<IPatient, Patient>();

            services.AddScoped<ITestReport, TestReport>();
            services.AddScoped<IPrescription, Prescription>();
            services.AddScoped<IAppointment, AppointmentRepo>();
            services.AddScoped<IPayment, Payment>();
            services.AddScoped<IEmlpoyeeRepo, EmployeeRepo>();
            services.AddScoped<IRole, Role>();
            services.AddScoped<IDepartment, Department>();
            services.AddScoped<ILogin, LoginRepo>();
            services.AddScoped<IAnnouncement, Repository.Announcement>();
            services.AddScoped<IDoctorNotesRepo, DoctorNotesRepo>();


            services.AddControllers().AddNewtonsoftJson(
                    options =>
                    {
                        options.SerializerSettings
                        .ContractResolver = new DefaultContractResolver();

                        options.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    }
                );

            //--- register a JWT authentication schema ---//
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });

            services.AddCors();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
                options.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
