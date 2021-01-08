using _17bangMvc.Filters;
using Global;
using ServiceInterface.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Email;

namespace _17bangMvc.Controllers
{
    public class EmailController : BaseController
    {
        #region Constructor
        private IEmailService service;
        public EmailController(IEmailService service)
        {
            this.service = service;
        }
        #endregion

        #region Url:/Email/Activate
        [HttpGet]
        [NeedLogOnFilter]
        public ActionResult Activate()
        {
            return View(service.GetActivate());
        }

        [HttpPost]
        [NeedLogOnFilter]
        public ActionResult Activate(ActivateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            bool validated = service.PassedValidation(model);
            if (validated)
            {
                return PrepageUrlHelper.Return();
            }
            else
            {
                ModelState.AddModelError("AuthCode", "* Email或验证码错误");
                return View(model);
            }
        }
        #endregion
        public JsonResult IsDuplicatedOnAddress(string Address)
        {
            return Json(!service.IsDuplicatedOnAddress(Address),
                JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult _Validate(string address)
        {
            EmailValidationResult result = service.Send(address);
            return Json(result.ToString());
        }
    }
}