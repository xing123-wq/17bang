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
            IList<SeriesModel> models = new List<SeriesModel>();
            models = service.Get(service.CurrentUserId.Value);
            return View(models);
        }
        [ChildActionOnly]
        [HttpGet]
        public ActionResult _NewInManage()
        {
            SeriesModel model = new SeriesModel();
            model.SelectLists = service.GetSelectListItems(service.Get(service.CurrentUserId.Value));
            return View(model);
        }
        [HttpPost]
        public ActionResult _NewInManage(SeriesModel model)
        {
            int id = service.Save(model);
            return Redirect($"/Category/Manage?id={id}");
        }

    }
}