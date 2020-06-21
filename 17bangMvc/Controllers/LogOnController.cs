﻿using _17bangMvc.Helper;
using ExtensionMethods;
using ProdService;
using ServiceInterface;
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
        private ILogOnService _service;
        public LogController()
        {
            _service = new LogOnService();
        }
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
            IndexModel user = _service.GetBy(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError(nameof(model.UserName), "* 用户不存在");
                return View(model);
            }
            if (user.Password != model.Password.GetMd5Hash())
            {
                ModelState.AddModelError(nameof(model.Password), "* 用户名或者密码错误");
            }
            int userId = _service.LogOn(model);
            CookieHelper.LogOn(userId, model.Password, model.RememberMe);
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