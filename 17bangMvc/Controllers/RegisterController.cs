using ProdService;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Register;

namespace _17bangMvc.Controllers
{
    public class RegisterController : Controller
    {
        private IRegisterService _Iservice;
        public RegisterController()
        {
            _Iservice = new RegisterService();
        }
        [HttpGet]
        public ActionResult index()
        {
            ViewData["title"] = "注册:一起帮";
            return View();
        }
        [HttpPost]
        public ActionResult index(IndexModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["title"] = "注册:一起帮";
                return View(model);
            }
            //_Iservice.Register(model);
            return View(model);
        }
    }
}