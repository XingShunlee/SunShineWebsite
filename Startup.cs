using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ehaiker;
using ehaikerv202010.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;

namespace ehaikerv202010
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //定义应用所使用的服务。
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMemoryCache();//using cacheing technoligy
            services.AddDistributedMemoryCache();//the depence of session
            services.AddSession(options=>{
                options.Cookie.Name="AspnetCore";
                options.IdleTimeout=TimeSpan.FromSeconds(300*10000);
            });//使用session服务
            //SQLServer
            var connection = @"Server=localhost;uid=root; Database=NetNote; pwd=netnote5316;port=3306;sslmode=Preferred";
            services.AddDbContext<EhaikerContext>(
               // options=>options.UseSqlServer(connection));
            options => options.UseMySQL(connection));
            services.AddTransient<EncodeService>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.AddMvc(
                options =>
                {
                    options.Filters.Add(typeof(PermissionRequiredAttribute));
                    options.Filters.Add(typeof(LoginStateRequiredAttribute));
                    options.Filters.Add(typeof(AdminLoginStateRequiredAttribute));
                    options.Filters.Add(typeof(NoPermissionRequiredAttribute));
                }
                ).SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();

                }
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        ///用于定义你的请管道中的中间件
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();//
            app.UseStaticFiles();//开启静态文件
                                 //开放某个文件夹
                                 /* app.UseStaticFiles(new StaticFileOptions(){
                                      FileProvider=new PhysicalFileProvider(
                                          Path.Combine(Directory.GetCurrentDirectory(),@"wwwroot/images")),//物理地址
                                          RequestPath= new PathString("/myImages")}//请求地址
                                      );*/
                                 //开启目录浏览
             
           /* app.UseDirectoryBrowser(new DirectoryBrowserOptions(){
                     
                FileProvider=new PhysicalFileProvider(
                    Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location),@"wwwroot/images")),//物理地址
                    RequestPath= new PathString("/myImages")}//请求地址
                );*/
            app.UseCookiePolicy();//开启cookie
            app.UseSession();//使用session
                             //  app.UseRequestIP("jhaoihdahaof");
          //  app.UseAuthentication( );
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=EHaiker}/{action=Index}/{id?}");
            });
        }
    }
}
