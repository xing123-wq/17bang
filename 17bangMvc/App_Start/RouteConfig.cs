using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _17bangMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ArticleUserPaged",
                url: "Article/User-{userId}/Page-{pageIndex}",
                defaults: new { controller = "Article", action = "User" },
                constraints: new { userId = @"\d+", pageIndex = @"\d+" }
            );


            routes.MapRoute(
                name: "ArticlePage",
                url: "{controller}/Page-{pageIndex}",
                defaults: new { controller = "Article", action = "Index", pageIndex = UrlParameter.Optional },
                constraints: new { pageIndex = @"^[0-9]*[1-9][0-9]*$" });


            routes.MapRoute(
                name: "ArticleSingle",
                url: "{controller}/{Id}",
                defaults: new { controller = "Article", action = "Single", Id = UrlParameter.Optional },
                constraints: new { Id = @"^[0-9]*[1-9][0-9]*$" });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { id = @"\d*" });


            routes.MapRoute(
                name: "CategoryEidt",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Category", action = "_New", id = UrlParameter.Optional },
                constraints: new { id = @"^[0-9]*[1-9][0-9]*$" });

            routes.MapRoute(
                name: "CategoryDelete",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Category", action = "_Delete", id = UrlParameter.Optional },
                constraints: new { id = @"^[0-9]*[1-9][0-9]*$" });
        }
    }
}
