using System;
using System.Collections.Generic;
using System.Linq;
using _17bnag.Data;
using _17bnag.Entitys;
using _17bnag.Helper;
using _17bnag.Layout;
using Microsoft.EntityFrameworkCore;

namespace _17bnag.Pages
{
    public class ArticleModel : _LayoutModel
    {
        public IEnumerable<PublishArticle> articles { get; set; }
        public int Pageindex { get; set; }
        public int Pagesize { get; set; }
        public int Sum { get; set; }
        public ArticleModel(_17bnagContext context) : base(context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Pagesize = Helper.Const.PAGE_SIZE;
            Pageindex = Convert.ToInt32(Request.RouteValues["id"]);
            Sum = ExtensionMethod.GetSum(_context.PublishArticles);
            articles = _context.PublishArticles.Include(m=>m.keywords).ThenInclude(k=>k.Keyword).Include(h => h.Author).ToList();
            articles = ExtensionMethod.Get(articles.OrderByDescending(a => a.PublishTime), Pageindex, Pagesize);
            base.SetLogOnStatus();
            ViewData["title"] = "精品文章--一起帮";
        }
    }
}