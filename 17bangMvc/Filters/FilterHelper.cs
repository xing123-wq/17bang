using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17bangMvc.Filters
{
    public class FilterHelper
    {
        internal static void returnAjaxError(ActionExecutingContext filterContext)
        {
            var state = filterContext.Controller.ViewData.ModelState;
            throw new Exception("Ajax请求未能通过输入验证，错误信息为：" +
                getErrorMessages(state));
        }

        internal static string getErrorMessages(ModelStateDictionary model)
        {
            return string.Join(",",
                    model.Values.Where(E => E.Errors.Count > 0)
                    .SelectMany(E => E.Errors)
                    .Select(E => E.ErrorMessage)
                    .ToArray());
        }
    }
}