using System;
using System.Collections.Generic;
using System.Linq;
using _17bnag.Data;
using _17bnag.Entitys;
using _17bnag.Layout;
using Microsoft.EntityFrameworkCore;

namespace _17bnag.Pages
{
    public class ArticleModel : _LayoutModel
    {
        public IList<PublishArticle> articles { get; set; }
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
            Pageindex = Convert.ToInt32(Request.Query["Page"]);
            Sum = _context.GetArticle();
            articles = _context.PublishArticles.Include(h => h.Author).ToList();
            articles = Get(Pageindex, Pagesize);
            base.SetLogOnStatus();
            ViewData["title"] = "精品文章--一起帮";
        }
        public List<PublishArticle> Get(int Pageindex, int pagesize)
        {
            return articles.OrderByDescending(p => p.PublishTime)
                .Skip((Pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
    }
}