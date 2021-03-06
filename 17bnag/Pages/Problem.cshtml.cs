﻿using System;
using System.Collections.Generic;
using System.Linq;
using _17bnag.Data;
using _17bnag.Entitys;
using _17bnag.Layout;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using _17bnag.Helper;
using Microsoft.AspNetCore.Mvc;

namespace _17bnag.Pages
{
    public class ProblemModel : _LayoutModel
    {
        public ProblemModel(_17bnagContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<HelpRelease> Problems { get; set; }
        public int pagesize { get; set; }
        public int pageindex { get; set; }
        public int sum { get; set; }
        public void OnGet()
        {
            //string exclude = Request.Query["exclude"];
            //if (string.IsNullOrEmpty(exclude))
            //{
            //    Problems = _context.HelpRelease.Include(h => h.Users).ToList();
            //    Problems = Get(pageindex, pagesize);
            //}
            //else
            //{
            //    Problems = GetExclude(Enum.Parse<ProblemStatus>(exclude));
            //}
            pagesize = Const.PAGE_SIZE;
            pageindex = Convert.ToInt32(Request.RouteValues["id"]);
            sum = ExtensionMethod.GetSum(_context.HelpRelease);
            Problems = _context.HelpRelease.Include(h => h.Users).ToList();
            Problems = ExtensionMethod.Get(Problems.OrderByDescending(p => p.PublishDateTime), pageindex, pagesize);
            ViewData["title"] = "首页-一起帮";
            base.SetLogOnStatus();
        }
        public IActionResult Post()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return Page();
        }
        //public IList<HelpRelease> GetExclude(ProblemStatus status)
        //{
        //    return Problems.Where(p => p.Status != status.GetDescription()).ToList();
        //}
    }
    public enum ProblemStatus
    {
        [Description("已撤销")]
        Cancelled,
        [Description("协助中")]
        InProcess,
        [Description("已酬谢")]
        Rewarded
    }
}