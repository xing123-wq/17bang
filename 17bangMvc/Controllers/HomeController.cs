using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Home;

namespace _17bangMvc.Controllers
{
    public class HomeController : BaseController
    {
        #region Constructor 
        private IBaseService service;
        public HomeController(IBaseService service)
        {
            this.service = service;
        }
        #endregion

        #region Url:Index; Requset:Get;
        [HttpGet]
        public ActionResult Index(IndexModel model)
        {
            ViewData["title"] = "一起帮-首页";
            model.CurrentUserId = service.CurrentUserId;


            return View(model);
        }
        #endregion
    }
}