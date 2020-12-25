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
        private IBaseService _service;
        public NeedLogOnFilter()
        {
            _service = new BaseService();
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string pth = filterContext.HttpContext.Request.Path;
            if (_service.CurrentUserId == null)
            {
                filterContext.HttpContext.Response.Redirect($"/Log/On?pagepth={pth}");
            }
            base.OnAuthorization(filterContext);
        }
    }
}