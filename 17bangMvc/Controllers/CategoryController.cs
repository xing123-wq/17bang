using _17bangMvc.Filters;
using Global;
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
        #region constructor 
        private ISeriesService service;
        public CategoryController(ISeriesService service)
        {
            this.service = service;
        }
        #endregion

        #region Url:/Category/Manage
        [HttpGet]
        [NeedLogOnFilter(role: Role.Admin)]
        public ActionResult Manage()
        {
            ManageModel model = service.GetManage();
            return View(model);
        }
        #endregion

        #region PartialView

        #region Url:/Category/_New
        [HttpGet]
        [NeedLogOnFilter]
        public PartialViewResult _New(int? Id)
        {
            InputModel model = new InputModel();
            if (Id.HasValue)
            {
                model = service.GetBy(Id.Value);
            }
            model.Categories = service.GetSeries();
            return PartialView(model);
        }

        /// <summary>
        /// 由于Ajax请求，重定向到Manage，只会放会到Ajax的回调函数success当中，
        /// 所以如果要使用Ajax请求，就在success中用location.href
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [NeedLogOnFilter]
        public ActionResult _New(InputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            service.Save(model);
            return RedirectToAction("Manage");
        }
        #endregion

        #region Url:/Category/_Eidt 
        [HttpGet]
        [NeedLogOnFilter]
        public ActionResult _Eidt()
        {
            return View();
        }

        [HttpPost]
        [NeedLogOnFilter]
        public ActionResult _Eidt(InputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            service.Save(model, true);
            return RedirectToAction("Manage");
        }
        #endregion

        #region Url:/Category/_Delete/{id}

        [HttpPost]
        [NeedLogOnFilter]
        public ActionResult _Delete(int id)
        {
            service.Delete(id);
            return RedirectToAction("Manage");
        }
        #endregion

        [HttpGet]
        [NeedLogOnFilter]
        public JsonResult _IsDuplicatedOnTitle(string Title)
        {
            return Json(!service.IsDuplicatedOnName(Title),
                           JsonRequestBehavior.AllowGet);
        }

        #endregion

        [ChildActionOnly]
        public PartialViewResult _Item(int id)
        {
            SeriesItemMdodel model = service.Get(id);
            return PartialView(model);
        }

        public PartialViewResult _SubManage(int parentId)
        {
            return PartialView(service.GetSubManage(parentId));
        }
    }
}