using ProdService;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17bangMvc.Filters
{
    public class NeedLogOnFilter : AuthorizeAttribute
    {
        public BaseService service;
        public NeedLogOnFilter()
        {
            service = new BaseService();
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string pth = filterContext.HttpContext.Request.Path;
            if (service.CurrentUserId == null)
            {
                filterContext.HttpContext.Response.Redirect($"/Log/On?pagepth={pth}");
            }
            base.OnAuthorization(filterContext);
        }
    }
}