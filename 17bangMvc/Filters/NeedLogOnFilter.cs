using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17bangMvc.Filters
{
    public class NeedLogOnFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (true)
            {
                filterContext.HttpContext.Response.Redirect("");
            }
            base.OnAuthorization(filterContext);
        }
    }
}