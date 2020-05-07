using _17bnag.Helper;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bnag.Filter
{
    public class LogOnFilter : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            bool hasId = context.HttpContext.Request.Cookies.TryGetValue(Const.USER_ID, out string userId);
            string pth = context.HttpContext.Request.Path;
            if (!hasId)
            {
                context.HttpContext.Response.Redirect($"/Log/On?{Helper.Const.PAGE_PATH}={pth}");
            }
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {

        }

    }
}
