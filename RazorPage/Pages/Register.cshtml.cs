﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPage.Pages.Class;
using RazorPage.Pages.Helper;

namespace RazorPage
{
    [BindProperties]
    public class RegisterModel : _LayoutModel
    {
        public RegisterUser RegisteerOne { get; set; }
        public PageResult OnGet()
        {
            base.SetLogOnStatus();
            ViewData["title"] = "注册-一起帮";
            return Page();
        }
        public IActionResult OnPost()
        {
            new UserRepoistoy().Sava(RegisteerOne);
            RegisterUser user = _userRepoistoy.GetLog(RegisteerOne.Name);
            if (!ModelState.IsValid)
            {
                ViewData["title"] = "注册-一起帮";
                return Page();
            }
            if (user != null)
            {
                if (user.Name == RegisteerOne.Name)
                {
                    ModelState.AddModelError(Const.REGISTER_NAME, "* 用户名已存在");
                    return Page();
                }
                if (user.Password != RegisteerOne.Password.GetMd5Hash())
                {
                    ModelState.AddModelError(Const.REGISTER_PASSWORD, "* 用户名或者密码不正确");
                    return Page();
                }
            }
            if (user == null)
            {
                CookieOptions options = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(1)
                };
                ViewData[Const.REGISTER_NAME] = RegisteerOne.Name;
            }
            return RedirectToPage("/Register");

        }
    }
}