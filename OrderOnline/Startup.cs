using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.IRepository; 

namespace OrderOnline
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.AddScoped<ISalesOrderRepository, SalesOrderRepository>();
            #region Autofac IOC容器
           
            var builder = new ContainerBuilder();
            string basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
            
            string dllPath = Path.Combine(basePath, "Order.Service.dll");
            Assembly assembly = Assembly.LoadFile(dllPath);
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().InstancePerLifetimeScope();

            dllPath = Path.Combine(basePath, "Order.Repository.SqlSugar.dll");
            assembly = Assembly.LoadFile(dllPath);

            //通过这种方式进行注册，不能使用new创建对象 
            //用这种方式就可以使用new//builder.RegisterType<SalesOrderRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            //var t = assembly.GetTypes().FirstOrDefault(w=>w.Name== "SalesOrderRepository");
            //if (t!=null)
            //{
            //    builder.RegisterType(t).AsImplementedInterfaces().InstancePerLifetimeScope();
            //}


            builder.Populate(services);
            var container = builder.Build();
            var provider = new AutofacServiceProvider(container);
            
            return provider;
             
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
