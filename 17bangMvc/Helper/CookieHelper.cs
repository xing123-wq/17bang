using _17bangMvc.Filters;
using ExtensionMethods;
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
            HttpCookie cookie = new HttpCookie(Const.USER_NAME);

            //在cookie中添加若干（2个）键值对
            cookie.Values.Add(Const.USER_ID, id.ToString());
            cookie.Values.Add(Const.USER_PASSWORD, password.GetMd5Hash());
            if (remember)
            {
                cookie.Expires = DateTime.Now.AddDays(14);
            }
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}