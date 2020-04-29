using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bnag.Data;
using _17bnag.Entitys;
using _17bnag.Layout;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bnag.Article
{
    public class EditsModel : _LayoutModel
    {
        public EditsModel(_17bnagContext context) : base(context)
        {
            _context = context;
        }

        public PublishArticle Article { get; set; }
        public void OnGet()
        {
            int EditId = Convert.ToInt32(Request.RouteValues["id"]);
            Article = GetPublishArticle(EditId);
            base.SetLogOnStatus();
        }
        public void OnPost()
        {
        }
        public PublishArticle GetPublishArticle(int Id)
        {
            return _context.PublishArticles.Where(a => a.Id == Id).SingleOrDefault();
        }
    }
}