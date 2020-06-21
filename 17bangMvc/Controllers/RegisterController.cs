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
    public class RegisterController : Controller
    {
        private IRegisterService _iservice;
        public int UserId { get; set; }
        public RegisterController()
        {
            _iservice = new RegisterService();
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
            IndexModel user = _iservice.GetBy(model.UserName);
            IndexModel invier = _iservice.GetBy(model.Inviter);
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
            UserId = _iservice.Register(model);
            Cookies(model);
            return View(model);
        }
        public void Cookies(IndexModel model)
        {
            //首先有一个cookie，名字为user
            HttpCookie cookie = new HttpCookie(Const.USER_NAME);

            //在cookie中添加若干（2个）键值对
            string Id = UserId.ToString().GetMd5Hash();
            string password = model.Password.GetMd5Hash();
            cookie.Values.Add(Const.USER_ID, Id);
            cookie.Values.Add(Const.USER_PASSWORD, password);

            cookie.Expires = DateTime.Now.AddDays(14);
            //Request.Cookies.Add(cookie);
            Response.Cookies.Add(cookie);
        }
    }
}