using System;
using System.Collections.Generic;
using System.Linq;
using _17bnag.Data;
using _17bnag.Entitys;
using _17bnag.Helper;
using _17bnag.Layout;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _17bnag.Log
{
    [BindProperties]
    //[AddHeader]
    public class OnModel : _LayoutModel
    {
        public OnModel(_17bnagContext context) : base(context)
        {
            _context = context;
        }
        public LogOn Log { get; set; }
        public User LogOnOne { get; set; }
        public IList<User> Users { get; set; }
        public PageResult OnGet()
        {
            base.SetLogOnStatus();
            ViewData["title"] = "登录-一起帮";
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["title"] = "登录-一起帮";
                return Page();
            }
            User _user = GetLog(LogOnOne.Name);
            if (_user == null)
            {
                ModelState.AddModelError(Const.LOGON_LOGONUSERNAME, "* 用户名不存在");
                return Page();
            }
            if (_user.Password.GetMd5Hash() != LogOnOne.Password.GetMd5Hash())
            {
                ModelState.AddModelError(Const.LOGON_LOGONPASSWORD, "* 用户名或者密码不正确");
                return Page();
            }
            LogOnCookies();
            GetUrl();
            return Page();
        }
        public User GetLog(string name)
        {
            return _context.Users.Where(u => u.Name == name).SingleOrDefault();
        }
        public void LogOnCookies()
        {
            CookieOptions options = new CookieOptions();
            if (Log.RememberMe)
            {
                options.Expires = DateTime.Now.AddDays(14);
            }
            else
            {
                options.Expires = DateTime.Now.AddDays(1);
            }
            User _user = GetLog(LogOnOne.Name);
            Response.Cookies.Append(Const.USER_ID, _user.Id.ToString(), options);
            Response.Cookies.Append(Const.USER_PASSWORD, _user.Password.ToString().GetMd5Hash(), options);
            ViewData[Const.USER_NAME] = _user.Name;
        }
        public void GetUrl()
        {
            string pagepth = Request.Query[Helper.Const.PAGE_PATH];
            if (pagepth == "/Log/On"|| pagepth == "/Register")
            {
                Response.Redirect("/Index");
            }
            else
            {
                Response.Redirect(pagepth);
            }
        }

    }
}