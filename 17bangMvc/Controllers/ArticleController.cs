using _17bangMvc.Helper;
using ExtensionMethods;
using ProdService;
using ProdService.Articles;
using ProdService.Category;
using ServiceInterface;
using ServiceInterface.Category;
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
        private IArticleService _service;
        private ISeriesService _series;
        private IAdvertisingService _ad;
        public int pageindex { get; set; }
        public ArticleController(IArticleService service, ISeriesService series, IAdvertisingService ad)
        {
            this._service = service;
            this._series = series;
            this._ad = ad;
        }
        [HttpGet]
        public ActionResult index(IEnumerable<IndexModel> model)
        {
            ViewData["title"] = "精品文章-一起帮";
            pageindex = Convert.ToInt32(RouteData.Values["Id"]);//有了Id可以省略
            model = Select.Get(_service.GetBy(3), pageindex, Const.PAGE_SIZE);
            return View(model);
        }

        [HttpGet]
        public ActionResult New()
        {
            ViewData["title"] = "精品文章-一起帮";
            ViewData["SelectList"] = _series.GetSelectListItems(_series.Get(_service.CurrentUserId.Value));
            ViewData["ADs"] = _ad.GetSelectListItems(_ad.Get());
            return View();
        }

        [HttpPost]
        public ActionResult New(NewModel model)
        {
            ModelState.Remove("Digest");
            if (!ModelState.IsValid)
            {
                ViewData["SelectList"] = _series.GetSelectListItems(_series.Get(_service.CurrentUserId.Value));
                ViewData["ADs"] = _ad.GetSelectListItems(_ad.Get());
                ViewData["title"] = "精品文章-一起帮";
                return View(model);
            }
            if (string.IsNullOrEmpty(model.Digest))
            {
                model.Digest = model.Body.Substring(15);
            }
            _service.Save(model);
            return Redirect("/Article");
        }

    }
}