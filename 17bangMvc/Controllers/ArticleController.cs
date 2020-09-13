using ExtensionMethods;
using Global;
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
        #region Constructor 
        private IArticleService _service;
        private ISeriesService _series;
        private IAdvertisingService _ad;
        public ArticleController(IArticleService service, ISeriesService series, IAdvertisingService ad)
        {
            this._service = service;
            this._series = series;
            this._ad = ad;
        }
        #endregion

        #region Url:/Article;Requset:Get;
        [HttpGet]
        public ActionResult index(IEnumerable<IndexModel> model)
        {
            ViewData["title"] = "精品文章-一起帮";
            Pager pager = new Pager();
            pager.PageIndex = Convert.ToInt32(RouteData.Values["Id"]);
            model = Select.Get(_service.GetBy(3), pager.PageIndex, Const.PAGE_SIZE);
            return View(model);
        }
        #endregion

        #region Url:/Article/New; Requset:Get,Post;
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
        #endregion

        #region Url:/Aticle/User-{Id}; Requset:Get,Post;
        [HttpGet]
        public new ActionResult User(int Id)
        {
            ViewData["title"] = "精品文章.一起帮";
            Pager pager = new Pager();
            pager.PageIndex = Convert.ToInt32(RouteData.Values["Id"]);
            return View("User", _service.GetCurrentArticle(pager, Id));
        }
        #endregion

    }
}