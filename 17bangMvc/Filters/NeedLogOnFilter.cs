using Global;
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
        private Role _role;
        public IBaseService _service;
        public NeedLogOnFilter(Role role=Role.Logon)
        {
            this._role = role;
            _service = new BaseService();
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            HttpContextBase context = filterContext.HttpContext;

            string url = PrepageUrlHelper.GetFromUrl();
            if (_service.CurrentUserId == null)
            {
                if (context.Request.IsAjaxRequest())
                {
                    filterContext.Result = new PartialViewResult { ViewName = "_NotLogin" };
                }//else do nothing
                context.Response.Redirect($"/Log/On?{url}&Role={_role.GetDescription()}");
            }
            else
            {
                if (_role == Role.Admin)
                {
                    if (!_service.IsAdmin())
                    {
                        filterContext.Result = new PartialViewResult { ViewName = "_NotAdmin" };
                    }
                    return;
                }//else do nothing
                if (_role == Role.Blogger)
                {
                    if (!_service.IsBlogger())
                    {
                        filterContext.Result = new PartialViewResult { ViewName = "_NotBlogger" };
                    }
                    return;
                }//else do nothing
                PrepageUrlHelper.Return();
            }
        }
    }
}