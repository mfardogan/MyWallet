using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Turquoise.Administration.API
{
    using Turquoise.Administration.Domain;

    public class Startup
    {
        public Startup(IHostEnvironment env)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public IConfigurationRoot Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddOptions();
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Turquoise API",
                    Version = "v1",
                    Description = "API"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Jwt Authentication (Use \"Bearer\" <Your token>)",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference{Type = ReferenceType.SecurityScheme,  Id = "Bearer"  },
                              Scheme = "oauth2",
                              Name = "Bearer",
                              In = ParameterLocation.Header,
                            },
                            new List<string>()
                    }
                 });
            });
        }

        /// <summary>
        /// Manage services
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            Dependency.Instance.SetContainerBuilder(builder)
                .Register(new Application.IoC.ServiceContainer())
                .Register(new Infrastructure.SQL.IoC.ServiceContainer());
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Turquoise API");
            });

            ILifetimeScope lifetimeScope = app.ApplicationServices.GetAutofacRoot();
            Dependency.Instance.SetLifetimeScope(lifetimeScope);
        }
    }
}

