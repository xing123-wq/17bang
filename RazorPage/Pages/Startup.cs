using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RazorPage.Pages.Filters;

namespace RazorPage
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
               opt.Conventions.AddPageRoute("/Article/Page", "/Article/Page-{id:int}");
               opt.Conventions.AddPageRoute("/Article/User/Page", "/Article/User-{q:int}/Page-{w:int}");
               opt.Conventions.AddPageRoute("/Task/Historys", "/Task/Historys/{i:int}/{j:int}/{k:int}");
           });
            //.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc()
            .AddSessionStateTempDataProvider();
            services.AddMvc().AddMvcOptions(opt =>
            {
                opt.Filters.Add(new SampleFilters());
            });
            //session������Ҫһ���ط���MemoryCache�������
            services.AddMemoryCache();
            //����session
            services.AddSession(option =>
            {
                //�Զ���session��cookie����
                option.Cookie = new CookieBuilder
                {
                    Name = "MySessionId",
                    //ȷ��session��cookie����cookie policyӰ��
                    IsEssential = true
                };
                //session����Чʱ��Ϊ20���ӣ�����һ�λ�ȡsession��ʱ������
                option.IdleTimeout = new TimeSpan(0, 10, 0);
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
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();
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
