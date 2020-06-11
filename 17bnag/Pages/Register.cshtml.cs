using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _17bnag.Data;
using _17bnag.Entitys;
using _17bnag.Helper;
using _17bnag.Layout;
using _17bnag.Log;
using _17bnag.Model.Log;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _17bnag.Pages
{
    [BindProperties]
    public class RegisterModel : _LayoutModel
    {
        public RegisterModel(_17bnagContext context) : base(context)
        {
            _context = context;
        }
        public User RegisteerOne { get; set; }
        public PageResult OnGet()
        {
            base.SetLogOnStatus();
            ViewData["title"] = "注册-一起帮";
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["title"] = "注册-一起帮";
                return Page();
            }
            Model.Log.OnModel onModel = GetOnModel(RegisteerOne.OnModel.inviter);
            if (onModel != null)
            {
                if (onModel.inviter != RegisteerOne.OnModel.inviter)
                {
                    ModelState.AddModelError(Const.INVITER, "* 邀请人不正确");
                    return Page();
                }
                if (onModel.Code != RegisteerOne.OnModel.Code)
                {
                    ModelState.AddModelError(Const.INVITERCODE, "* 邀请码不正确");
                    return Page();
                }
            }
            else
            {
                ModelState.AddModelError(Const.INVITER, "* 邀请人不存在");
                return Page();
            }
            User user = GetLog(RegisteerOne.Name);
            if (user != null)
            {
                if (user.Name == RegisteerOne.Name)
                {
                    ModelState.AddModelError(Const.REGISTER_NAME, "* 用户名已存在");
                    return Page();
                }
            }
            RegisteerOne.OnModel.Time = DateTime.Now;
            Random random = new Random();
            RegisteerOne.OnModel.HelpMony += random.Next(0, 10);
            RegisteerOne.OnModel.Code = StringExtension.GenerateRandomNumber(4);
            _context.Users.Add(RegisteerOne);
            _context.SaveChanges();
            Cookies();
            GetUrl();
            return Page();
        }
        public Model.Log.OnModel GetOnModel(string inviter)
        {
            return _context.onModels.Where(o => o.inviter == inviter).SingleOrDefault();
        }
        public User GetLog(string name)
        {
            return _context.Users.Where(u => u.Name == name).SingleOrDefault();
        }
        public void Cookies()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);
            User _user = GetLog(RegisteerOne.Name);
            Response.Cookies.Append(Const.USER_ID, _user.Id.ToString(), options);
            Response.Cookies.Append(Const.USER_PASSWORD, _user.Password.ToString().GetMd5Hash(), options);
            ViewData[Const.USER_NAME] = _user.Name;
        }
        public void GetUrl()
        {
            string pagepth = Request.Query["pagepth"];
            if (pagepth == "/Log/On")
            {
                Response.Redirect("/Index");
            }
            else
            {
                Response.Redirect(pagepth);
            }
            if (pagepth == "/Register")
            {
                Response.Redirect("/Index");
            }
        }
    }
}