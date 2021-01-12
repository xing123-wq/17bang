using _17bangMvc.Filters;
using Global;
using ServiceInterface;
using ServiceInterface.Category;
using ServiceInterface.Shared;
using System;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI;
using ViewModel.Articles;
using ViewModel.Shared;
using ViewModel.Shared.Article;

namespace _17bangMvc.Controllers
{
    public class ArticleController : BaseController
    {
        #region Constructor 
        private IArticleService _service;
        private ISeriesService _series;
        private IAdvertisingService _ad;
        private IUserService _userService;
        public ArticleController(IArticleService service, ISeriesService series, IAdvertisingService ad, IUserService userService)
        {
            this._service = service;
            this._series = series;
            this._ad = ad;
            this._userService = userService;
        }
        #endregion

        #region Url:/Article;Requset:Get;
        [HttpGet]
        //Duration以秒为单位，VaryByParam=""，只要后面参数，有所改变，就会重新缓存
        [OutputCache(Duration = 100, Location = OutputCacheLocation.Any, VaryByParam = "id")]
        public ActionResult index(int pageindex = 1)
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

            Pager pager = new Pager
            {
                Index = pageindex,
                Size = Const.PAGE_SIZE
            };
            IndexModel model = _service.Get(pager);
            return View(model);
        }
        #endregion

        #region Url:/Article/New{Id}; Requset:Get,Post;
        [HttpGet]
        [NeedLogOnFilter(role: Role.Blogger)]
        public ActionResult New()
        {
            ViewData["title"] = "精品文章-一起帮";
            return View(_service.Get());
        }

        [HttpPost]
        [NeedLogOnFilter(role: Role.Blogger)]
        public ActionResult New(NewModel model)
        {
            if (!ModelState.IsValid)
            {
                model._Items = _ad.Get();
                model._Series = _series.GetSeries();
                return View(model);
            }
            _InputeModel _Inpute = model._Inpute;
            if (string.IsNullOrEmpty(_Inpute.Digest))
            {
                _Inpute.Digest = _Inpute.Body.Substring(15);
            }
            _service.Save(_Inpute);
            return Redirect("/Article");
        }
        #endregion

        #region Url:/Aticle/User; Requset:Get,Post;
        [HttpGet]
        [NeedLogOnFilter]
        public new ActionResult User(int userId, int pageIndex = 1)
        {
            ViewData["title"] = "精品文章.一起帮";
            Pager pager = new Pager
            {
                Index = pageIndex,
                Size = Const.PAGE_SIZE
            };
            return View("Index", _service.Get(userId, pager));
        }
        #endregion

        #region Url:/Article/{Id}; Requset: Get;
        [HttpGet]
        public ActionResult Single(int Id)
        {
            _SingleItemModel model = new _SingleItemModel();
            model = _service.GetSingle(Id);
            ViewBag.NavInCategory = navInCategory();
            ViewData["title"] = model.Title + ".一起帮";
            return View(model);
        }
        private bool navInCategory()
        {
            HttpCookie cookie = Request.Cookies["NavInCategory"];
            return cookie != null ?
                Convert.ToBoolean(cookie.Value) :
                false;
        }
        #endregion

        #region /Article/Edit{id}
        [HttpGet]
        [NeedLogOnFilter(role: Role.Blogger)]
        public ActionResult Edit(int id)
        {
            return View("New", _service.Get(id));
        }


        #endregion

        [ChildActionOnly]
        public PartialViewResult _PreAndNext(int id)
        {
            _PreAndNextModel model = _service.GetPreAndNext(id, navInCategory());
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult _MapSignsOfAuthor(int userId)
        {
            _UserModel model = _userService._Get(userId);
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult _Widget()
        {
            Pager pager = new Pager { Index = 1, Size = 5 };
            _WidgetModel model = _service.GetWidget(pager);
            return PartialView("Article/_Widget", model);
        }
    }
}