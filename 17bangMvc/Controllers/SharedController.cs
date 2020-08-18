using _17bangMvc.Helper;
using DrawingOperations;
using ExtensionMethods;
using Microsoft.Ajax.Utilities;
using ProdService;
using ServiceInterface;
using System;
using System.Collections.Generic;   
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17bangMvc.Controllers
{
    [Serializable]
    public class SharedController : BaseController
    {
        private ILogOnService _service;
        public SharedController()
        {
            _service = new LogOnService();
        }

        [ChildActionOnly]
        public PartialViewResult _Article()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public PartialViewResult _Keyword()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public PartialViewResult _RankingList()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public PartialViewResult _LogOn()
        {
            HttpCookie IdCookie = Request.Cookies.Get(Const.USER_ID);
            if (IdCookie != null)
            {
                string password = Request.Cookies[Const.USER_PASSWORD].Value;
                ViewModel.LogOn.IndexModel user = _service.GetBy();
                if (user != null)
                {
                    if (user.Password == password)
                    {
                        ViewData[Const.USER_NAME] = user.UserName;
                    }
                }
            }

            return PartialView();
        }

        public ActionResult Captcha()
        {
            string length = StringExtension.GetRandomNumber(4);
            HttpContext.Session[Const.CAPTCHA] = new SharedController();
            Session[Const.CAPTCHA] = length.GetMd5Hash();
            Verification.Captcha(length);
            MemoryStream stream = new MemoryStream();
            Verification.image.Save(stream, ImageFormat.Jpeg);
            return File(stream.ToArray(), "image/png");
        }
    }
}