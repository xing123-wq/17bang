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
            ManageModel model = new ManageModel
            {
                _Items = service.Get(service.CurrentUserId.Value)
            };
            return View(model);
        }

        public PartialViewResult _List()
        {
            ManageModel model = new ManageModel
            {
                _Items = service.Get(service.CurrentUserId.Value)
            };
            return PartialView(model);
        }
        #region Url:/Category/_New
        [HttpGet]
        public PartialViewResult _New(int Id)
        {
            ManageModel model = new ManageModel
            {
                _Input = service.GetBy(Id),
                _Items = service.Get(service.CurrentUserId.Value)
            };
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult _New(_InputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            service.Save(model);
            return RedirectToAction("Manage");
        }
        #endregion
    }
}