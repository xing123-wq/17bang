﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Global
{
    public class PrepageUrlHelper
    {
        public const string PREPAGE = "prepage";

        /// <summary>
        /// 从当前url中得到应该返回的之前页面路径
        /// </summary>
        /// <returns></returns>
        public static string GetFromUrl()
        {
            string prepageQuery = Const.PAGE_PATH + "=";
            //note: 必须每次从HttpContext.Current里面取，不要用类的static成员
            string prepage = HttpContext.Current.Request.QueryString[PREPAGE];
            HttpServerUtility server = HttpContext.Current.Server;

            if (string.IsNullOrEmpty(prepage))
            {
                HttpRequest request = HttpContext.Current.Request;
                return prepageQuery + server.UrlEncode(request.Url.PathAndQuery);
            }
            else
            {
                return prepageQuery + server.UrlEncode(prepage);
            }
        }

        /// <summary>
        /// 返回之前页面
        /// </summary>
        /// <param name="defaultUrl">如果Request中取不到之前页面，默认返回的url地址</param>
        /// <returns></returns>
        public static RedirectResult Return(string defaultUrl)
        {
            var request = HttpContext.Current.Request;
            string prepage = HttpContext.Current.Request.QueryString[PREPAGE];

            if (string.IsNullOrEmpty(prepage))
            {
                return new RedirectResult(defaultUrl);
            }
            else
            {
                return new RedirectResult(prepage);
            }
        }

        public static RedirectResult Return()
        {
            return Return(@"/");
        }
    }
}
