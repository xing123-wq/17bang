using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bnag.Data;
using _17bnag.Entitys;
using _17bnag.Layout;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _17bnag.Article
{
    [BindProperties]
    public class EditsModel : _LayoutModel
    {
        public EditsModel(_17bnagContext context) : base(context)
        {
            _context = context;
        }

        public PublishArticle Article { get; set; }
        public int EditId { get; set; }
        public void OnGet()
        {
            EditId = Convert.ToInt32(Request.RouteValues["id"]);
            Article = GetPublishArticle(EditId);
            ViewData["title"] = Article.Title + "-修改";
            base.SetLogOnStatus();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return Page();
            }
            Article.PublishTime = DateTime.Now;
            EditId = Convert.ToInt32(Request.RouteValues["id"]);
            Article.Id = EditId;
            Article.AuthorId = Convert.ToInt32(Request.Cookies[Helper.Const.USER_ID]);
            _context.PublishArticles.Update(Article);
            _context.SaveChanges();
            return RedirectToPage("/Article", new { id = 1 });
        }
        public PublishArticle GetPublishArticle(int Id)
        {
            return _context.PublishArticles.Where(a => a.Id == Id).SingleOrDefault();
        }
    }
}