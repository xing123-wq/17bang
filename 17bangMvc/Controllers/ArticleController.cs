using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Article;

namespace _17bangMvc.Controllers
{
    public class ArticleController : BaseController
    {
        [HttpGet]
        public ActionResult index()
        {
            ViewData["title"] = "精品文章-一起帮";
            return View();
        }
        [HttpPost]
        public ActionResult index(IndexModel model)
        {
            return View();
        }

         [HttpGet]
        public ActionResult index()
        {
            ViewData["title"] = "精品文章-一起帮";
            return View();
        }

        [HttpPost]
        public ActionResult New(NewModel model)
        {
            return View();
        }

    }
}