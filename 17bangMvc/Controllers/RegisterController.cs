using _17bangMvc.Helper;
using ExtensionMethods;
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
    public class RegisterController : BaseController
    {
        private readonly IRegisterService _service;
        public RegisterController()
        {
            _service = new RegisterService();
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
            IndexModel user = _service.GetBy(model.UserName);
            IndexModel invier = _service.GetBy(model.Inviter);
            if (invier == null)
            {
                ModelState.AddModelError(nameof(model.Inviter), "* 邀请人不存在");
                return View(model);
            }
            if (invier.InviterCode != model.InviterCode)
            {
                ModelState.AddModelError(nameof(model.InviterCode), "* 邀请码不正确，请重新输入");
                return View(model);
            }
            if (user != null)
            {
                ModelState.AddModelError(nameof(model.UserName), "* 该用户名已被使用");
                return View(model);
            }
            int UserId = _service.Register(model);
            CookieHelper.LogOn(UserId, model.Password);
            return View(model);
        }
    }
}