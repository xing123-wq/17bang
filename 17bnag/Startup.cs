using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using _17bnag.Data;
using Microsoft.AspNetCore.Mvc;
using _17bnag.Filters;
using _17bnag.Layout;

namespace _17bnag
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddMvc()
            .AddRazorPagesOptions(opt =>
            {
                opt.Conventions.AddPageRoute("/Article/Single", "/Article/{id:int}");
                opt.Conventions.AddPageRoute("/Article/Edits", "/Article/Edits/{id:int}");
                opt.Conventions.AddPageRoute("/Article/Category", "/Article/Category/Page-{id:int}");
                opt.Conventions.AddPageRoute("/Article/User", "/Article/User-{id:int}");
                opt.Conventions.AddPageRoute("/Article/index", "/Article/Page-{id:int}");
                opt.Conventions.AddPageRoute("/Pages/Article/index", "/Article");
                opt.Conventions.AddPageRoute("/Article/User/Page", "/Article/User-{q:int}/Page-{w:int}");
                opt.Conventions.AddPageRoute("/Task/Historys", "/Task/Historys/{i:int}/{j:int}/{k:int}");
                opt.Conventions.AddPageRoute("/Problems/indexs", "/Problems/{id:int}");
                opt.Conventions.AddPageRoute("/Problems/Delete", "/Problems/Delete/{id:int}");
                opt.Conventions.AddPageRoute("/Problems/Details", "/Problems/Details/{id:int}");
                opt.Conventions.AddPageRoute("/Problems/Edit", "/Problems/Edit/{id:int}");
                opt.Conventions.AddPageRoute("/Problem", "/Problem/Page-{id:int}");
                opt.Conventions.AddPageRoute("/Pages/Notices/index", "/Notices");
                opt.Conventions.AddPageRoute("/Notices/Edit", "/Notices/Edit/{id:int}");
            })/*.SetCompatibilityVersion(CompatibilityVersion.Version_3_0)*/;
            services.AddMvc()
            .AddSessionStateTempDataProvider();
            //services.AddMvc().AddMvcOptions(opt =>
            //{
            //    opt.Filters.Add(new SampleFilters());
            //});
            //session首先需要一定地方（MemoryCache）来存放
            services.AddMemoryCache();
            //引入session
            services.AddSession(option =>
            {
                //自定义session的cookie名字
                option.Cookie = new CookieBuilder
                {
                    Name = "MySessionId",
                    //确保session的cookie不受cookie policy影响
                    IsEssential = true
                };
                //session的有效时间为20分钟，从上一次获取session的时间起算
                option.IdleTimeout = new TimeSpan(0, 10, 0);
            });

            services.AddDbContext<_17bnagContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("_17bnagContext")));
            services.AddMvc()
               .AddMvcOptions(options =>
               {
                   options.Filters.Add(new GlobalFilter());
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                CheckConsentNeeded = (x => false)
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                CheckConsentNeeded = (x => false)
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
