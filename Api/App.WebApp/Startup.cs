using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using App.Data.DataBase;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using App.WebApp.Startup;
using NLog.Extensions.Logging;
using NLog.Web;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.AspNetCore.Mvc.Authorization;
using AutoMapper;
using App.WebApp;

namespace Appapp
{
    public class Startup
    {
        // 默认的跨域请求策略名称
        private const string _defaultCorsPolicyName = "AppCors";

        /// <summary>
        ///获取配置组件
        /// </summary>
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // 配置依赖注入容器
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return InitIoC(services);
        }

        // 配置应用程序中间件管道
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //添加NLog日志
            loggerFactory.AddNLog();
            env.ConfigureNLog("NLog.config");

            //全局错误
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseCors(_defaultCorsPolicyName);
            app.UseMiniProfiler();
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DemoAPI V1");
                if (Configuration["PerformanceMonitoring"]=="true") {
                    c.IndexStream = () => GetType().GetTypeInfo().Assembly.GetManifestResourceStream("App.WebApp.SaggerIndex.html");
                }
            });

        }

        //用autofac替换应用程序默认注入容器。
        private IServiceProvider InitIoC(IServiceCollection services)
        {
            //配置数据源连接字符串
            var dbConnectionString = Configuration.GetConnectionString("MsSqlServer");
            services.AddDbContext<EFDbContext>(options => options.UseSqlServer(dbConnectionString));

            //设置跨域授权策略，之允许 配置【"Application:CorsOrigins"】中的地址访问接口
            services.AddCors(options => options.AddPolicy(_defaultCorsPolicyName,
            builder => builder.WithOrigins(
                    Configuration["Application:CorsOrigins"]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray()
                )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()));

            //版本控制 暂时不用
            //services.AddApiVersion();

            //添加 对EF 生成sql的监控
            services.AddMiniProfiler(options => {
                options.PopupShowTimeWithChildren = true;
                options.RouteBasePath = "/profiler";
            }).AddEntityFramework();

            //添加MVC 服务
            services.AddMvc(options => {
                // 添加 CORS 授权过滤器
                options.Filters.Add(new CorsAuthorizationFilterFactory(_defaultCorsPolicyName));
                //权限过滤
                if (Configuration["JwtSettings:Isenable"] == "true")
                {
                    options.Filters.Add(new AuthorizeFilter());
                }
             }).AddJsonOptions(setupAction => { 
                 // 忽略循环引用,规避EntityFramework导航属性json序列化时的循环引用问题 
                 setupAction.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                 // 使用默认json序列化,规避字段小驼峰命名法 
                 //setupAction.SerializerSettings.ContractResolver = new DefaultContractResolver(); 
                 // 设置json序列化的日期时间格式 
                 setupAction.SerializerSettings.DateFormatString = "yyyy-MM-dd"; 
             }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

                //配置autoMapper
                services.AddAutoMapper(typeof(ServiceProfile));

            //添加 swagger 可视化
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                   Version = "v1",
                   Title = "CMS接口文档",
                   Description = "CMS 接口可视化"
                });
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "TextApi.xml");//和上面图片中xml地址相同
                c.IncludeXmlComments(xmlPath,true);//添加控制器层注释（true表示显示控制器注释）

                #region 启用swagger验证功能
                //添加一个必须的全局安全信息，和AddSecurityDefinition方法指定的方案名称一致即可，CoreAPI。
                var security = new Dictionary<string, IEnumerable<string>> { { "CoreAPI", new string[] { } }, };
                c.AddSecurityRequirement(security);
                c.AddSecurityDefinition("CoreAPI", new ApiKeyScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 在下方输入Bearer {token} 即可，注意两者之间有空格",
                    Name = "Authorization",//jwt默认的参数名称
                    In = "header",//jwt默认存放Authorization信息的位置(请求头中)
                    Type = "apiKey"
                });
                #endregion
            });

            //添加 jwt权限认证
            AuthConfiguer.Configuer(services, Configuration);

            //autofac 替换core 默认注入
            return AutofacContainer.Init(services,Configuration);
        }
    }
}
