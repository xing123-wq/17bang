using System;
using System.Collections.Generic;
using System.Linq;
using _17bnag.Data;
using _17bnag.Entitys;
using _17bnag.Layout;
using Microsoft.EntityFrameworkCore;

namespace _17bnag.Pages
{
    public class ProblemModel : _LayoutModel
    {
        public ProblemModel(_17bnagContext context) : base(context)
        {
            _context = context;
        }

        public IList<HelpRelease> Problems { get; set; }
        public int pagesize { get; set; }
        public int pageindex { get; set; }

        public void OnGet()
        {
            pagesize = 5;
            pageindex = Convert.ToInt32(Request.Query["Page"]);
            Problems = _context.HelpRelease.Include(h => h.User).ToList();
            Problems = Get(pageindex, pagesize);
            ViewData["title"] = "首页-一起帮";
            base.SetLogOnStatus();
        }
        public void Post()
        {
        }
        public IList<HelpRelease> Get(int pageindex, int pagesize)
        {
            return Problems.OrderByDescending(p => p.PublishDateTime)
                .Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
    }
}