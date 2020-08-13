using ProdService.Category;
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
        private SeriesService service;
        public CategoryController()
        {
            service = new SeriesService();
        }
        [HttpGet]
        public ActionResult Manage()
        {
            SeriesModel models = new SeriesModel();
            models.SeriesModels = service.Get(service.CurrentUserId.Value);
            return View(models);
        }
        [HttpGet]
        public ActionResult _NewInManage()
        {
            SeriesModel model = new SeriesModel();
            ViewData["SelectLists"] = service.GetSelectListItems(service.Get(service.CurrentUserId.Value));
            return View(model);
        }
        [HttpPost]
        public ActionResult _NewInManage(SeriesModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["SelectLists"] = service.GetSelectListItems(service.Get(service.CurrentUserId.Value));
                return View("Manage", model);
            }
            service.Save(model);
            return Redirect("/Category/Manage");
        }

    }
}