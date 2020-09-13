using _17bangMvc.Filters;
using ExtensionMethods;
using Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _17bangMvc.Helper
{
    public class CookieHelper
    {
        public static void LogOn(int id, string password, bool remember = false)
        {
            //首先有一个cookie，名字为user
            HttpCookie Password = new HttpCookie(Const.USER_PASSWORD);
            HttpCookie UserId = new HttpCookie(Const.USER_ID);
            //在cookie中添加若干（2个）键值对
            UserId.Value = id.ToString();
            Password.Value = password.GetMd5Hash();
            if (remember)
            {
                Password.Expires = DateTime.Now.AddDays(14);
                UserId.Expires = DateTime.Now.AddDays(14);
            }
            HttpContext.Current.Response.Cookies.Add(UserId);
            HttpContext.Current.Response.Cookies.Add(Password);
        }
    }
}