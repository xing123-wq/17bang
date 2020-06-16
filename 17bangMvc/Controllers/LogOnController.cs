using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.LogOn;

namespace _17bangMvc.Controllers
{
    public class LogController : Controller
    {
        [HttpGet]
        //[Route("Log/On")]
        public ActionResult On()
        {
            ViewData["title"] = "用户登录:一起帮";
            return View();
        }
        //[Route("Log/On")]
        [HttpPost]
        public ActionResult On(IndexModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["title"] = "用户登录:一起帮";
            }
            return View(model);
        }
        [HttpGet]
        [Route("Log/Off")]
        public ActionResult Off()
        {
            return RedirectToAction("");
        }
    }
}