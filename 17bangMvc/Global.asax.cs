using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace _17bangMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()//项目起点 
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //1. 获得一个ContainerBuilder（容器建造器）对象 
            ContainerBuilder builder = new ContainerBuilder();

            //2. 注册Controller和FilterProvider
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterFilterProvider();

            //配置：指示使用何种interface实例呢？
            //2.1 可以一个类一个类的注册
            //builder.RegisterType<MockUserService>().As<IUserService>();

            //2.2 也可以整个程序集的注册
            builder.RegisterAssemblyTypes(typeof(ProdService.BaseService).Assembly)
                .AsImplementedInterfaces();

            //3. 通过ContainerBuilder得到一个IContainer容器对象，
            //4. 并为MVC自动设定解析（resolve：获取“接口对象”）
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
