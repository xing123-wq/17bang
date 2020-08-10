using ProdService.Articles;
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
        private SeriesService Series;
        public SeriesController()
        {
            Series = new SeriesService();
        }
        [HttpGet]
        public ActionResult _Series()
        {
            SeriesModel model = new SeriesModel();
            model.SelectLists = Series.GetSelectListItems(Series.Get(Series.CurrentUserId.Value));
            return View(model);
        }
        [HttpPost]
        public ActionResult _Series(SeriesModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Series.Save(model);
            return View(model);
        }
        
    }
}