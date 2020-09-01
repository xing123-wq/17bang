using _17bangMvc.Filters;
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
    public class CategoryController : BaseController
    {
        private ISeriesService service;
        public CategoryController(ISeriesService service)
        {
            this.service = service;
        }
        [HttpGet]
        public ActionResult Manage()
        {
            SeriesModel model = new SeriesModel();
            ViewData["SelectLists"] = service.GetSelectListItems(service.Get(service.CurrentUserId.Value));
            model.SeriesModels = service.Get(service.CurrentUserId.Value);
            return View(model);
        }

        [HttpPost]
        public ActionResult Manage(SeriesModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["SelectLists"] = service.GetSelectListItems(service.Get(service.CurrentUserId.Value));
                model.SeriesModels = service.Get(service.CurrentUserId.Value);
                return View(model);
            }
            service.Save(model);
            return View(model);
        }

    }
}