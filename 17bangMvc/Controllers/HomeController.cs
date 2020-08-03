using ProdService;
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
        private BaseService service;
        public HomeController()
        {
            service = new BaseService();
        }
        [HttpGet]
        public ActionResult Index(IndexModel model)
        {
            ViewData["title"] = "一起帮-首页";
            model.CurrentUserId = service.CurrentUserId;
            return View(model);
        }
        //[HttpPost]
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
    }
}