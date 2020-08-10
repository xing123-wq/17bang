using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17bangMvc.Controllers
{
    public class CategoryController : Controller
    {
        [HttpGet]
        public ActionResult Manage()
        {
            return View();
        }
    }
}