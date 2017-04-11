using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ConfigurationSample.AppSettings;

namespace ConfigurationSample
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            //構成ファイル、環境変数等から、構成情報をロード
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            //構成情報をプロパティに設定
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            //構成情報から、UserSettings クラスへバインド
            services.Configure<UserSettings>(this.Configuration.GetSection("UserSettings"));
            services.Configure<PageSettings>(this.Configuration.GetSection("PageSettings"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //各構成情報の取得
            //ブール値のロード
            bool isDemoMode = this.Configuration.GetValue<bool>("UserSettings:IsDemoMode");
            //文字列値のロードは、インデクサで指定可能
            string defaultUserName = this.Configuration["UserSettings:DefaultUser:Name"];
            //int 値のロード
            int defaultUserAge = this.Configuration.GetValue<int>("UserSettings:DefaultUser:Age");
            

            
    
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
