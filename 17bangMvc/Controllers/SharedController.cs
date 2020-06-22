﻿using _17bangMvc.Helper;
using Microsoft.Ajax.Utilities;
using ProdService;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.LogOn;

namespace _17bangMvc.Controllers
{
    public class SharedController : BaseController
    {
        private ILogOnService _service;
        public SharedController()
        {
            _service = new LogOnService();
        }
        [ChildActionOnly]
        public PartialViewResult _Advertising()
        {
            return PartialView();
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
                int userId = Convert.ToInt32(IdCookie.Value);
                string password = Request.Cookies[Const.USER_PASSWORD].Value;
                IndexModel user = _service.GetBy(userId);
                if (user.Password == password)
                {
                    ViewData[Const.USER_NAME] = user.UserName;
                }
            }

            return PartialView();
        }
    }
}