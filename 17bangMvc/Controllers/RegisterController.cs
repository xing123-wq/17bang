﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Register;

namespace _17bangMvc.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public ActionResult index()
        {
            ViewData["title"] = "注册:一起帮";
            return View();
        }
        [HttpPost]
        public ActionResult index(IndexModel model)
        {
            ViewData["title"] = "注册:一起帮";
            return View();
        }
    }
}