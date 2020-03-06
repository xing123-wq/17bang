﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Models;

namespace _17bangMvc.Controllers
{
    public class ProblemController : Controller
    {
        [HttpGet]
        public ActionResult index()
        {
            ViewData["title"] = "一起帮-求助页";
            return View();
        }
        [HttpPost]
        public ActionResult index(ProblemModel model)
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