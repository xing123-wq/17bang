﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _17bnag.Layout;
using _17bnag.Data;
using Microsoft.EntityFrameworkCore;
namespace _17bnag.Article
{
    public class SingleModel : _LayoutModel
    {
        public Entitys.PublishArticle Articles { get; set; }
        public SingleModel(_17bnagContext context) : base(context)
        {
            _context = context;
        }
        public void OnGet()
        {
            int articleId = Convert.ToInt32(Request.RouteValues["id"]);
            Articles = _context.GetSngle(articleId);
            ViewData["title"] = Articles.Title;
            base.SetLogOnStatus();
        }
    }
}