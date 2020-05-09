using _17bnag.Data;
using _17bnag.Entitys;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bnag.Pages.Shared
{
    public class _Article : ViewComponent
    {
        private _17bnagContext _context { get; set; }
        public _Article(_17bnagContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            IList<PublishArticle> articles = _context.PublishArticles.OrderByDescending(a => a.PublishTime).ToList();
            return View("_Article", articles);
        }
    }
}
