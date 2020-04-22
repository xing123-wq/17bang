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
    public class AllPageFilter : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            bool hasId = context.HttpContext.Request.Cookies.TryGetValue(Const.USER_ID, out string userId);
            if (!hasId)
            {
                context.HttpContext.Response.Redirect("/Log/On");
            }
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {

        }

    }
}
