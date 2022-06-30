using System;
using EBono_API.Accounts.Domain.Repositories;
using EBono_API.Accounts.Domain.Services;
using EBono_API.Accounts.Persistence.Repositories;
using EBono_API.Accounts.Services;
using EBono_API.Bonds.Domain.Repositories;
using EBono_API.Bonds.Domain.Services;
using EBono_API.Bonds.Persistence.Repositories;
using EBono_API.Bonds.Services;
using EBono_API.Results.Domain.Repositories;
using EBono_API.Results.Domain.Services;
using EBono_API.Results.Persistence.Repositories;
using EBono_API.Results.Services;
using EBono_API.Security.Authorization.Handlers.Implementations;
using EBono_API.Security.Authorization.Handlers.Interfaces;
using EBono_API.Security.Authorization.Middleware;
using EBono_API.Security.Authorization.Settings;
using EBono_API.Shared.Domain.Repositories;
using EBono_API.Shared.Persistence.Contexts;
using EBono_API.Shared.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EBono_API
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
            services.AddCors();
            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EBono_API", Version = "v1" });
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddDbContext<AppDbContext>();
            
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IBondRepository, BondRepository>();
            services.AddScoped<IBondService, BondService>();
            services.AddScoped<IResultRepository, ResultRepository>();
            services.AddScoped<IResultService, ResultService>();
            services.AddScoped<IJwtHandler, JwtHandler>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EBono_API v1"));
            
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware<JwtMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}