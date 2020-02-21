﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bnag.Data;
using _17bnag.Entitys;
using _17bnag.Layout;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bnag.Problems
{
    [BindProperties]
    public class NewsModel : _LayoutModel
    {
        public readonly _17bnagContext _context;
        public LogOnUser OnUserName { get; set; }
        public HelpRelease ReleaseOn { get; set; }
        public HelpRelease help { get; set; }
        public NewsModel(_17bnagContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            base.SetLogOnStatus();
            ViewData["title"] = "(新消息)我要求助--一起帮";
        }
        public async Task<IActionResult> OnPost()
        {
            //help.Author = OnUserName;
            help.PublishDateTime = DateTime.Now;
            _context.HelpRelease.Add(help);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Problem");
        }
    }
}
