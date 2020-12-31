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

        #region Url:/Category/_New
        [HttpGet]
        public PartialViewResult _New(int? Id)
        {
            _InputModel model = new _InputModel();
            if (Id.HasValue)
            {
                model = service.GetBy(Id.Value);
            }
            model._Items = service.Get(service.CurrentUserId.Value);
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
        [HttpGet]
        public ActionResult _Eidt()
        {
            return View();
        }

        [HttpPost]
        public ActionResult _Eidt(_InputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.Id == model.ParentId)
            {
                throw new ArgumentException($"系列Id为：{model.Id}," +
                                           $"父系列Id为：{model.ParentId}，" +
                                           $"两者不能相同。");
            }
            service.Save(model, true);
            return RedirectToAction("Manage");
        }

        [HttpPost]
        public ActionResult _Delete(int id)
        {
            service.Delete(id);
            return RedirectToAction("Manage");
        }

        [HttpGet]
        public JsonResult _IsDuplicatedOnTitle(string Title)
        {
            return Json(!service.IsDuplicatedOnName(Title),
                           JsonRequestBehavior.AllowGet);
        }

    }
}