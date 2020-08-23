using _17bangMvc.Helper;
using ExtensionMethods;
using ProdService;
using ProdService.Articles;
using ProdService.Category;
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
        public int pageindex { get; set; }
        public ArticleController()
        {
            _service = new ArticleService();
        }
        [HttpGet]
        public ActionResult index(/*int Id,*/IEnumerable<IndexModel> model)
        {
            ViewData["title"] = "精品文章-一起帮";
            model = _service.GetBy(3);
            pageindex = Convert.ToInt32(RouteData.Values["Id"]);//有了Id可以省略
            model = Select.Get(model.OrderByDescending(a => a.PublishTime), pageindex, Const.PAGE_SIZE);
            return View(model);
        }

        [HttpGet]
        public ActionResult New()
        {
            ViewData["title"] = "精品文章-一起帮";
            NewModel model = new NewModel();
            SeriesService Service = new SeriesService();
            ViewData["SelectList"] = Service.GetSelectListItems(Service.Get(_service.CurrentUserId.Value));
            AdService advertising = new AdService();
            ViewData["ADs"] = advertising.GetSelectListItems(advertising.Get());
            return View(model);
        }

        [HttpPost]
        public ActionResult New(NewModel model)
        {
            if (!ModelState.IsValid)
            {
                SeriesService Service = new SeriesService();
                ViewData["SelectList"] = Service.GetSelectListItems(Service.Get(_service.CurrentUserId.Value));
                AdService advertising = new AdService();
                ViewData["ADs"] = advertising.GetSelectListItems(advertising.Get());
                ViewData["title"] = "精品文章-一起帮";
                return View(model);
            }
            _service.Save(model);
            return Redirect("/Article");
        }

    }
}