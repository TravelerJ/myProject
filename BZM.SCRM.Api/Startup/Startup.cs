using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BZM.SCRM.Domain;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Abp.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Abp.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;
using BZM.SCRM.Api.filter;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.AspNetCore.Mvc.Versioning;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;
using BZM.SCRM.Api.Application;
using Abp.Reflection.Extensions;
using Abp.AspNetCore.SignalR.Hubs;

namespace BZM.SCRM.Api.Startup
{
    /// <summary>
    /// 启动器
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services">服务池</param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var con = Configuration["ConnectionStrings:SCRM"];
            services.AddAbpDbContext<SCRMDbContext>(options =>
            {
                var connectionString = Configuration["ConnectionStrings:SCRM"];
                SCRMDbContextOptionsConfigurer.Configure(options.DbContextOptions, connectionString);
            });
            services.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            })
                .ConfigureApplicationPartManager(manager =>
                {
                    var oldMetadataReferenceFeatureProvider = manager.FeatureProviders.First(f => f is MetadataReferenceFeatureProvider);
                    manager.FeatureProviders.Remove(oldMetadataReferenceFeatureProvider);
                    manager.FeatureProviders.Add(new ReferencesMetadataReferenceFeatureProvider());
                })

                .AddJsonOptions(options =>
                {
                    //JSON序列化规则：默认命名方式，禁用首字母大写 或小写的处理
                    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                    //JSON序列化规则：日期格式化
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind;
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                });

            //增加接口版本控制
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.ApiVersionReader = ApiVersionReader.Combine(new HeaderApiVersionReader("api-version"), new QueryStringApiVersionReader("api-version"));
            });

            services
                .AddMvcCore(option =>
                {
                    option.Filters.Add<AuthorizationFilter>();
                })
                .AddAuthorization()
                .AddJsonFormatters();

            services
                .AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Configuration["AppSettings:IdsUrl"];
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "api1";
                });
            services.AddSignalR();
            // Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1.0", new Info { Title = "车服云平台接口文档-基础设置",Description= "System", Version= "v1.0" });
                options.SwaggerDoc("v1.1", new Info { Title = "车服云平台接口文档-微信平台", Description = "WeChatPlatform", Version = "v1.1" });
                options.SwaggerDoc("v1.2", new Info { Title = "车服云平台接口文档-服务管理", Description = "ServiceManagement", Version = "v1.2" });
                options.SwaggerDoc("v1.3", new Info { Title = "车服云平台接口文档-资讯与活动", Description = "InformationActivitie", Version = "v1.3" });
                options.SwaggerDoc("v1.4", new Info { Title = "车服云平台接口文档-商城管理", Description = "MallManagement", Version = "v1.4" });
                // This call remove version from parameter, without it we will have version as parameter 
                // for all endpoints in swagger UI
                options.OperationFilter<RemoveVersionParameterFilter>();

                // This make replacement of v{version:apiVersion} to real version of corresponding swagger doc.
                options.DocumentFilter<ReplaceDocVersionParameterFilter>();

                // This on used to exclude endpoint mapped to not specified in swagger version.
                // In this particular example we exclude 'GET /api/v2/Values/otherget/three' endpoint,
                // because it was mapped to v3 with attribute: MapToApiVersion("3")
                options.DocInclusionPredicate((version, desc) =>
                {
                    var versions = desc.ControllerAttributes()
                        .OfType<ApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions);

                    var maps = desc.ActionAttributes()
                        .OfType<MapToApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions)
                        .ToArray();

                    return versions.Any(v => $"v{v.ToString()}" == version) && (maps.Length == 0 || maps.Any(v => $"v{v.ToString()}" == version));
                }
                );

                // Assign scope requirements to operations based on AuthorizeAttribute
                //options.OperationFilter<SecurityRequirementsOperationFilter>();

                // Define the BearerAuth scheme that's in use
                options.AddSecurityDefinition("bearerAuth", new ApiKeyScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                //添加文档注释
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                //BZM.DC.Api.xml
                var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                var applicationFileName = typeof(SCRMApiApplicationModule).GetAssembly().GetName().Name + ".xml";
                var domainFileName = typeof(SCRMCoreModule).GetAssembly().GetName().Name + ".xml";
                if (File.Exists(Path.Combine(baseDirectory, commentsFileName)))
                {
                    options.IncludeXmlComments(Path.Combine(baseDirectory, commentsFileName));
                }
                if (File.Exists(Path.Combine(baseDirectory, applicationFileName)))
                {
                    options.IncludeXmlComments(Path.Combine(baseDirectory, applicationFileName));
                }
                if (File.Exists(Path.Combine(baseDirectory, domainFileName)))
                {
                    options.IncludeXmlComments(Path.Combine(baseDirectory, domainFileName));
                }
            });


            services.AddCors(options =>
                options.AddPolicy("AllowSameDomain",
                    builder => builder.AllowAnyOrigin()
                    //.WithOrigins("http://localhost:8080")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                  ));

            return services.AddAbp<ScrmApiModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAbp();
            app.UseStaticFiles();
            app.UseCors("AllowSameDomain");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseSignalR(routes =>
            {
                routes.MapHub<SignalRHub>("/user");
            });
            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "defaultWithArea",
                //    template: "{area}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}",
                    defaults: new { routeOrigin = "default" });
            });



            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUI(options =>
            {
                options.InjectOnCompleteJavaScript("/swagger/ui/md5.min.js");
                options.InjectOnCompleteJavaScript("/swagger/ui/on-complete.js");
                options.SwaggerEndpoint("/swagger/v1.0/swagger.json", "System");
                options.SwaggerEndpoint("/swagger/v1.1/swagger.json", "WeChatPlatform");
                options.SwaggerEndpoint("/swagger/v1.2/swagger.json", "ServiceManagement");
                options.SwaggerEndpoint("/swagger/v1.3/swagger.json", "InformationActivitie");
                options.SwaggerEndpoint("/swagger/v1.4/swagger.json", "MallManagement");
            });


        }
    }
}
