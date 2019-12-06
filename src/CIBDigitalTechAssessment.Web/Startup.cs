using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CIBDigitalTechAssessment.Abstractions.Interfaces;
using CIBDigitalTechAssessment.Core.Interfaces;
using CIBDigitalTechAssessment.Core.Services;
using CIBDigitalTechAssessment.EntityFramework;
using CIBDigitalTechAssessment.EntityFramework.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]

namespace CIBDigitalTechAssessment.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
 

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddDistributedMemoryCache();
            services.AddHttpClient();
            
            services.AddPhoneBookDbContext<PhoneBookDbContext>(
                connectionString: Configuration.GetConnectionString(name: "PhoneBookDbConnection"));
            services.AddScoped(serviceType: typeof(IEntityRepository<>),
                implementationType: typeof(EntityRepository<>));
            services.AddScoped(serviceType: typeof(IViewRepository<>),
                implementationType: typeof(ViewRepository<>));
            
            services.AddScoped<IPhoneBookService, PhoneBookService>();
            
            services.AddRazorPages().AddRazorPagesOptions(options => { });
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(item: new JsonStringEnumConverter());
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });
            services.AddSwaggerGen(setupAction: c =>
            {
                c.SwaggerDoc(name: "v1",
                    info: new OpenApiInfo
                          {
                              Title = "CIB Digital Tech Assessment",
                              Version = "v1",
                              Contact = new OpenApiContact
                                        {
                                            Email = "lionel@lionelchetty.dev"
                                        }
                          }
                );
                c.EnableAnnotations();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            app.UseStaticFiles();
            var forwardedHeaderOptions = new ForwardedHeadersOptions
                                         {
                                             ForwardedHeaders =
                                                 ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                                         };
            forwardedHeaderOptions.KnownNetworks.Clear();
            forwardedHeaderOptions.KnownProxies.Clear();

            app.UseForwardedHeaders(options: forwardedHeaderOptions);

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(setupAction: c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "CIB Digital Tech Assessment Api");
                c.RoutePrefix = "swagger";
            });

            app.UseEndpoints(endpoints =>
            {
               
                endpoints.MapRazorPages();
                endpoints.MapControllers();
               
            });
        }
    }
}