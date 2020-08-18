using ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Ad;

namespace _17bangMvc.Controllers
{
    public class AdInWidgetController : Controller
    {
        [ChildActionOnly]
        [HttpGet]
        public PartialViewResult _Advertising()
        {
            AdService service = new AdService();
            IList<ViewModel.Ad.IndexModel> models = service.GetByads(5);
            return PartialView(models);
        }
        [ChildActionOnly]
        [HttpGet]
        public ActionResult _Ad()
        {
            IndexModel model = new IndexModel();
            AdService service = new AdService();
            model.ADS = service.GetUserId(service.CurrentUserId.Value);
            ViewData["SelectADList"] = service.GetSelectListItems(model.ADS);
            return View(model);
        }
        [HttpPost]
        [ChildActionOnly]
        public ActionResult _Ad(IndexModel model)
        {
            AdService service = new AdService();
            if (!ModelState.IsValid)
            {
                ViewData["SelectADList"] = service.GetSelectListItems(model.ADS);
                return View(model);
            }
            service.Sava(model);
            return View(model);
        }

        [ChildActionOnly]
        [HttpGet]
        public PartialViewResult _Advertising(ViewModel.Ad.IndexModel model)
        {

            return PartialView();
        }
    }
}