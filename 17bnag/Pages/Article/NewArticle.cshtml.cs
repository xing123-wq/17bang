﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bnag.Data;
using _17bnag.Entitys;
using _17bnag.Layout;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bnag
{
    [BindProperties]
    public class NewArticleModel : _LayoutModel
    {
        public _17bnagContext _context;
        public PublishArticle PublishesOn { get; set; }
        public NewArticleModel(_17bnagContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            base.SetLogOnStatus();
        }
        public async Task<IActionResult> OnPost()
        {
            //help.Author = OnUserName;
            PublishesOn.PublishTime = DateTime.Now;
            _context.PublishArticles.Add(PublishesOn);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Article");
        }
    }
}