using _17bangMvc.Filters;
using _17bangMvc.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17bangMvc.Controllers
{
    [ContextPerRequest]
    public class BaseController : Controller
    {
        public BaseController()
        {
        }
        public ActionResult GetByPagePath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return Redirect("/");
            }
            if (path == "/Log/On")
            {
                return Redirect("/");
            }
            if (path == "/Register")
            {
                return Redirect("/");
            }
            return Redirect(path);
        }
    }
}