using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Register;

namespace _17bangMvc.Controllers
{
    public class LogOnController : Controller
    {
        HttpCookie cookie = new HttpCookie("UserName");
        [HttpGet]
        [Route("Log/On")]
        public ActionResult index()
        {
            ViewData["title"] = "用户登录:一起帮";
            return View();
        }
        [Route("Log/On")]
        [HttpPost]
        public ActionResult index(IndexModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["title"] = "用户登录:一起帮";
            }
            Cookie(model);
            return View(model);
        }
        [HttpGet]
        [Route("Log/Off")]
        public ActionResult Off()
        {
            Response.AppendCookie(cookie);
            Request.Cookies.Remove("UserName");
            return RedirectToAction("index");
        }
        public void Cookie(IndexModel model)
        {
            //if (model.RememberMe)
            //{
            //    cookie.Expires = DateTime.Now.AddDays(14);
            //}
            //else
            //{
            //    cookie.Expires = DateTime.Now.AddDays(1);
            //}
            //Response.Cookies.Add(cookie);
        }
    }
}