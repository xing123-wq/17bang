using ProdService.Category;
using ServiceInterface.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Category;

namespace _17bangMvc.Controllers
{
    public class SeriesController : BaseController
    {
        private ISeriesService Series;
        public SeriesController(ISeriesService Series)
        {
            this.Series = Series;
        }
        [ChildActionOnly]
        [HttpGet]
        public ActionResult _Series()
        {
            SeriesModel model = new SeriesModel();
            ViewData["SelectList"] = Series.GetSelectListItems(Series.Get(Series.CurrentUserId.Value));
            return View(model);
        }
        [HttpPost]
        public ActionResult _Series(SeriesModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["SelectList"] = Series.GetSelectListItems(Series.Get(Series.CurrentUserId.Value));
                throw new Exception("用户输入不服规定");
            }
            Series.Save(model);
            return Redirect("/Article/New");
        }

    }
}