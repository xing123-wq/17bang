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
            _InputModel model = new _InputModel();
            if (Id.HasValue)
            {
                model = service.GetBy(Id.Value);
            }
            model._Items = service.GetSeries();
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

        #region Url:/Category/_Eidt 
        [HttpGet]
        [NeedLogOnFilter]
        public ActionResult _Eidt()
        {
            return View();
        }

        [HttpPost]
        [NeedLogOnFilter]
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

        [HttpGet]
        public ActionResult _Series()
        {
            _InputModel model = new _InputModel
            {
                _Items = service.GetSeries()
            };
            return View(model);
        }

        [HttpPost]
        [NeedLogOnFilter]
        public ActionResult _Series(_InputModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("用户输入不服规定");
            }
            service.Save(model);
            return Redirect("/Article/New");
        }


        #endregion

        [ChildActionOnly]
        public PartialViewResult _Item(int id)
        {
            _SeriesItemMdodel model = service.Get(id);
            return PartialView(model);
        }
    }
}