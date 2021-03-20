using System.Collections.Generic;
using APITreiber.DomainModel;
using APITreiber.Persistence.UnitOfWork;
using APITreiber.Persistence.UnitOfWork.Contracts;
using APITreiber.Services.PersonService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace APITreiber
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()                
                .AddFluentValidation(fv => { fv.RegisterValidatorsFromAssemblyContaining<Startup>();});
            
            
            var dataAssemblyName = typeof(AppDbContext).Assembly.GetName().Name;
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration
                    .GetConnectionString("IdentityServerDatabase"), 
                x => x.MigrationsAssembly(dataAssemblyName)));
            
            //Service 

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPersonService ,PersonService>();
            
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                

            }).AddJwtBearer(options =>
            {
                options.Authority = Configuration["ConfigIdentity:UrlIdentityServer"];
                options.Audience = Configuration["ConfigIdentity:APIName"];
                options.RequireHttpsMetadata = false;
                
            });
            
            services.AddVersionedApiExplorer(op =>
            {
                op.GroupNameFormat = "'v'VVV";
                op.SubstituteApiVersionInUrl = true;
            });
            
            services.AddApiVersioning(op => op.ReportApiVersions = true);

            services.AddSwaggerGen(c =>
            {
              c.SwaggerDoc("v1", new OpenApiInfo {Title = "APITreiber", Version = "v1"});
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT containing userid claim",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });

                var security =
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Id = "Bearer",
                                    Type = ReferenceType.SecurityScheme
                                },
                                UnresolvedReference = true
                            },
                            new List<string>()
                        }
                    };
                c.AddSecurityRequirement(security);
            });
            
            services.AddAutoMapper(typeof(Startup));
           
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APITreiber v1"));
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
           

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}