using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bnag.Data;
using _17bnag.Entitys;
using _17bnag.Filter;
using _17bnag.Filters;
using _17bnag.Layout;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _17bnag.Article
{
    [BindProperties]
    [LogOnFilter]
    public class EditsModel : _LayoutModel
    {
        public EditsModel(_17bnagContext context) : base(context)
        {
            _context = context;
        }

        public PublishArticle Article { get; set; }
        public void OnGet()
        {
            int Id = Convert.ToInt32(Request.RouteValues["id"]);
            int userId = Convert.ToInt32(Request.Cookies[Helper.Const.USER_ID]);
            Article = GetPublishArticle(Id);
            if (Article.AuthorId != userId)
            {
                throw new Exception($"当前用户Id:{userId}，不是当前文章的作者Id:{Article.AuthorId}");
            }
            ViewData["title"] = Article.Title + "-修改";
            base.SetLogOnStatus();
        }
        public IActionResult OnPost()
        {
            Article.PublishTime = DateTime.Now;
            int Id = Convert.ToInt32(Request.RouteValues["id"]);
            int userId = Convert.ToInt32(Request.Cookies[Helper.Const.USER_ID]);
            Article.AuthorId = userId;
            Article.keywords = GetString();
            _context.PublishArticles.Update(Article);
            _context.SaveChanges();
            return Redirect($"/Article/{Id}");
        }
        public PublishArticle GetPublishArticle(int Id)
        {
            return _context.PublishArticles.Where(a => a.Id == Id).SingleOrDefault();
        }
        public IList<ArticleMap> GetString()
        {
            IList<ArticleMap> maps = new List<ArticleMap>();
            if (!string.IsNullOrEmpty(Article.Keyword))
            {
                IList<string> SKeywords = Article.Keyword.Trim().Split(" ");
                for (int i = 0; i < SKeywords.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(SKeywords[i]))
                    {
                        continue;
                    }
                    ArticleMap articleMaps = new ArticleMap { Keyword = new Keyword { Name = SKeywords[i] } };
                    maps.Add(articleMaps);
                }
            }
            return maps;
        }
    }
}