using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bnag.Data;
using _17bnag.Entitys;
using _17bnag.Filter;
using _17bnag.Helper;
using _17bnag.Layout;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bnag.Problems
{
    [AllPageFilter]
    [BindProperties]
    public class NewsModel : _LayoutModel
    {
        public HelpRelease help { get; set; }
        public NewsModel(_17bnagContext context) : base(context)
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
            //help.Status = Pages.ProblemStatus.Cancelled.GetDescription();
            help.PublishDateTime = DateTime.Now;
            _context.HelpRelease.Add(help);
            help.UserId = Convert.ToInt32(Request.Cookies[Const.USER_ID]);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Problem");
        }

    }
}
