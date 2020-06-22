using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Problem;

namespace _17bangMvc.Controllers
{
    public class ProblemController : BaseController
    {
        [HttpGet]
        public ActionResult index()
        {
            ViewData["title"] = "一起帮-求助页";
            return View();
        }
        [HttpPost]
        public ActionResult index(NewModel model)
        {
            return View();
        }
        [HttpGet]
        public ActionResult New()
        {
            ViewData["title"] = "我要求助:一起帮";
            return View();
        }
        [HttpPost]
        public ActionResult New(NewModel model)
        {
            return View();
        }
    }
}