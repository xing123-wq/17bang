using _17bnag.Data;
using _17bnag.Entitys;
using _17bnag.Layout;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace _17bnag.Filters
{
    public class EditsFilter : IPageFilter
    {
        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {

        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {

        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)//1
        {
            int id = Convert.ToInt32(context.HttpContext.Request.RouteValues["id"]);
            int userId = Convert.ToInt32(context.HttpContext.Request.Cookies[Helper.Const.USER_ID]);
            //if (Article.AuthorId != userId)
            //{
            //    throw new Exception("当前用户不是当前文章的作者");
            //}
        }
    }
}
