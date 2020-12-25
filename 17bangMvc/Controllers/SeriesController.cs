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
            return View(new ManageModel()._Items = Series.Get(Series.CurrentUserId.Value));
        }
        [HttpPost]
        public ActionResult _Series(ManageModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("用户输入不服规定");
            }
            Series.Save(model);
            return Redirect("/Article/New");
        }

       
    }
}