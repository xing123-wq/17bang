using _17bnag.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bnag.Filters
{
    public class GlobalFilter : IPageFilter
    {
        public void OnPageHandlerSelected(PageHandlerSelectedContext context)//1
        {
            bool hasId = context.HttpContext.Request.Cookies.TryGetValue(Const.USER_ID, out string userId);
            if (!hasId)
            {

            }

        }
        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)//2
        {

        }
        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)//3
        {

        }
        public void LogOnCookies()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(14);
            //Response.Cookies.Append(Const.ALL_INFORM, _user.Id.ToString(), options);
        }
    }
}
