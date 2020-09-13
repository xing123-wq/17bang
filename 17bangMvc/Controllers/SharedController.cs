using _17bangMvc.Helper;
using DrawingOperations;
using ExtensionMethods;
using Global;
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
        #region Constructor
        public SharedController()
        {

        }
        #endregion

        #region Captcha
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
        #endregion
    }
}