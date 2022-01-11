using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using RestApi.Data.Entities;
using RestApi.Data.Exceptions;
using RestApi.Data.Helper;
using RestApi.Data.Infrastructure;
using RestApi.Data.Repositories;
using RestApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace RestApi
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

            services.AddControllers(options =>
            {
                //dùng middle error thì config tại đây
                options.Filters.Add<HttpResponseExceptionFilter>();
            });
            services.AddDbContextPool<AppDBContext>(options =>
             options.UseSqlServer(
                 Configuration.GetConnectionString("DbConnection")));
            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddTransient<IDbFactory, DbFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IEmployeeReponsitory, EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestApi", Version = "v1" });
            });
            var setretKey = Configuration["AppSettings:Secret"];
            var setretKeyBytes = Encoding.UTF8.GetBytes(setretKey);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt=> {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    //tự cấp token
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    //cấu hình sinh token
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(setretKeyBytes)//IdentityModel.Tokens;
                };
            });
                // add AspNetCore.Authentication.JwtBearer
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestApi v1"));
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
