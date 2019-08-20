using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using App.Data.DataBase;
using App.Repositories.IRepository;
using App.Repositories.Repository;
using App.Service.CoreServices;
using App.Service.Interface;

namespace App.WebApp.Startup
{
    public static class AutofacContainer
    {
        /// <summary>
        /// 容器实例
        /// </summary>
        public static IContainer Instance;

        /// <summary>
        /// 初始化容器
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IServiceProvider Init(IServiceCollection services, IConfiguration configuration, Func<ContainerBuilder, ContainerBuilder> func = null)
        {
            //新建容器构建器，用于注册组件和服务
            var builder = new ContainerBuilder();
            //将Core自带DI容器内的服务迁移到AutoFac容器
            builder.Populate(services);
            //自定义注册组件
            MyBuild(builder, configuration);
            func?.Invoke(builder);
            //利用构建器创建容器
            Instance = builder.Build();

            return new AutofacServiceProvider(Instance);
        }

        /// <summary>
        /// 自定义注册
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="builder"></param>
        public static void MyBuild(this ContainerBuilder builder, IConfiguration configuration)
        {

            var baseTypeDomain = typeof(App.Core.IAutoInject);
            Assembly assemblyService = Assembly.Load("App.Service");
            Assembly assemblyRepositories = Assembly.Load("App.Repositories");
            //自动注册接口

            builder.RegisterAssemblyTypes(assemblyService,assemblyRepositories)
                .Where(b => b.GetInterfaces().Any(c => c == baseTypeDomain && b != baseTypeDomain))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            var jwtoption = new JwtSettings();
            configuration.GetSection("JwtSettings").Bind(jwtoption);

            builder.RegisterInstance<JwtSettings>(jwtoption);
            builder.RegisterType<EFDbContext>().As<IDbContext>().InstancePerLifetimeScope();

        }
    }
}
