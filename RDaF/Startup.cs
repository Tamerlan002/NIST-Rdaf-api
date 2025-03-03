using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RDaF.Api.Infrastructure;
using RDaF.Api.Mapping;
using RDaF.Api.Modules;
using RDaF.Data.EntityFramework.Context;
using RDaF.Shared.Constants;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace RDaF.Api
{
    public class Startup
    {

        private const string CorsPolicyName = "EnableCORS";


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Auto Mapper Configurations
            services.AddSingleton(AutoMapperConfig.CreateMapper());
            services.AddHttpContextAccessor();

            //TimeZoneInfo bakuTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Baku");

            EnableCrossModule.Load(services, CorsPolicyName);

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    //options.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter(bakuTimeZone.Id));
                })
                .AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            // Auto Mapper Configurations
            services.AddSingleton(AutoMapperConfig.CreateMapper());

            services.AddMvc(options => { options.Filters.Add(typeof(HttpGlobalExceptionFilter)); })
                .AddControllersAsServices();


            //For MYSQL, since remote db is postgresql
            //services.AddDbContext<RDaFDbContext>(options =>
            //{
                //options.UseMySQL(
                //    Configuration.GetConnectionString("ConnectionString"),
                //    mysqlOptions =>
                //    {
                //        mysqlOptions.MigrationsAssembly("RDaF.Data");
                //        mysqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(3), null); // Pass 'null' as the third argument
                //    });
            //});



            var settings = Configuration.Get<RDaFSettings>();
            var token = Configuration.GetSection("Token").Value;
            services.Configure<RDaFSettings>(Configuration);

            // Identity Server Configurations
            IdentityServerModule.Load(services);

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            ConfigureSwagger(services);

            // Configure DI for application services
            LogicModule.Load(services);

        }


        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env
            /*RDaFDbContext context*/)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", true, true)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
              .AddEnvironmentVariables();
            Configuration = builder.Build();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsStaging())
            {
                app.UseFileServer(new FileServerOptions
                {
                    EnableDirectoryBrowsing = false
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var feature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = feature.Error;

                var result = JsonConvert.SerializeObject(new { error = exception.Message });
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }));

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DefaultModelsExpandDepth(-1);
                c.DocExpansion(DocExpansion.None);
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
            });

            app.UseRouting();
            app.UseCors(CorsPolicyName);


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}");
            });
            //Task.Run(async () => await SeedRegions.Seed(context));

            //OneXTwoDbContext.Seed(context, userManager, roleManager).Wait();
        }




        #region HelperMethods

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "RDaF API",
                    Version = "v1",
                    Description = "The RDaF API"
                });

                options.CustomSchemaIds(type => type.ToString());

                // No security setup required anymore, so we removed it entirely
            });
        }

        #endregion




    }
}
