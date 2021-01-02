using _17bangMvc.Filters;
using ExtensionMethods;
using Global;
using ProdService;
using ProdService.Articles;
using ProdService.Category;
using ServiceInterface;
using ServiceInterface.Category;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI;
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
        [OutputCache(Duration = 100, Location = OutputCacheLocation.Any, VaryByParam = "id")]
        public ActionResult index(IEnumerable<IndexModel> models)
        {
            ViewData["title"] = "精品文章-一起帮";

            #region SqlCacheDependency  缓存
            //string cachekey = "user_1";
            //models = HttpContext.Cache.Get(cachekey) as IEnumerable<IndexModel>;
            //if (models is null)
            //{
            //    models = _service.GetBy(6);
            //    HttpContext.Cache.Add(cachekey, models, new SqlCacheDependency("18bang", "Articles"), DateTime.MaxValue,
            //        new TimeSpan(0, 20, 0), CacheItemPriority.NotRemovable,
            //        (k, v, r) => { Trace.WriteLine($"cache with key:{k},value:{v}is deleted,reason:{r}"); });
            //}//else do nothing 
            #endregion

            Pager pager = new Pager();
            pager.PageIndex = Convert.ToInt32(RouteData.Values["Id"]);
            models = Select.Get(_service.GetBy(3), pager.PageIndex, Const.PAGE_SIZE);
            return View(models);
        }
        #endregion

        #region Url:/Article/New; Requset:Get,Post;
        [HttpGet]
        [NeedLogOnFilter]
        public ActionResult New()
        {
            ViewData["title"] = "精品文章-一起帮";
            NewModel model = new NewModel
            {
                _Series = _series.GetSeries(),
                _Items = _ad.Get(),
            };
            return View(model);
        }

        [HttpPost]
        [NeedLogOnFilter]
        public ActionResult New(_InputeModel model)
        {
            ModelState.Remove("Digest");
            if (!ModelState.IsValid)
            {
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
        [NeedLogOnFilter]
        public new ActionResult User(int Id)
        {
            ViewData["title"] = "精品文章.一起帮";
            Pager pager = new Pager();
            pager.PageIndex = Convert.ToInt32(RouteData.Values["Id"]);
            return View("User", _service.GetCurrentArticle(pager, Id));
        }
        #endregion

        #region Url:/Article/{Id}; Requset: Get;
        [HttpGet]
        public ActionResult Single(int Id)
        {
            IndexModel model = new IndexModel();
            model = _service.GetSingle(Id);
            ViewData["title"] = model.Title + ".一起帮";
            return View(model);
        }
        #endregion
    }
}