using ExtensionMethods;
using ProdService;
using ProdService.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Articles;

namespace _17bangMvc.Controllers
{
    public class ArticleController : BaseController
    {
        private ArticleService _service;
        public ArticleController()
        {
            _service = new ArticleService();
        }
        [HttpGet]
        public ActionResult index(IList<IndexModel> model)
        {
            ViewData["title"] = "精品文章-一起帮";
            model = _service.GetBy(3);
            return View(model);
        }
        //[HttpPost]
        //public ActionResult index(IList<IndexModel> model)
        //{
        //    return View(model);
        //}

        [HttpGet]
        public ActionResult New()
        {
            ViewData["title"] = "精品文章-一起帮";
            NewModel model = new NewModel();
            SeriesService Service = new SeriesService();
            model.Serieses = Service.GetSelectListItems(Service.Get());
            AdService advertising = new AdService();
            model.ADs = advertising.GetSelectListItems(advertising.Get());
            return View(model);
        }

        [HttpPost]
        public ActionResult New(NewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["title"] = "精品文章-一起帮";
                return View(model);
            }
            _service.Save(model);
            return View(model);
        }

    }
}