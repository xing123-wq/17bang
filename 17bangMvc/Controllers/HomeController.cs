﻿using SRV.ViewModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Models;

namespace _17bangMvc.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["title"] = "一起帮-首页";
            return View();
        }
        [HttpPost]
        public ActionResult Index(IndexModel model)
        {
            return View();
        }
        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
    }
}