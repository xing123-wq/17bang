using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bnag.Data;
using _17bnag.Entitys;
using _17bnag.Filter;
using _17bnag.Layout;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _17bnag
{
    [BindProperties]
    [LogOnFilter]
    public class NewArticleModel : _LayoutModel
    {
        public PublishArticle PublishesOn { get; set; }
        public NewArticleModel(_17bnagContext context) : base(context)
        {
            _context = context;
        }
        public void OnGet()
        {
            base.SetLogOnStatus();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            PublishesOn.keywords = GetString();
            Publish();
            _context.PublishArticles.Add(PublishesOn);
            _context.SaveChanges();
            return Redirect("/Article");
        }
        public void Publish()
        {
            PublishesOn.AuthorId = Convert.ToInt32(Request.Cookies[Helper.Const.USER_ID]);
            PublishesOn.PublishTime = DateTime.Now;
            PublishesOn.Author = GetUser(PublishesOn.AuthorId);
            PublishesOn.Author.OnModel.HelpMony -= 1;
            PublishesOn.Author.OnModel.HelpPoint += 1;
            PublishesOn.Author.OnModel.HelpBeans += 1;
        }
        public IList<ArticleMap> GetString()
        {
            IList<ArticleMap> maps = new List<ArticleMap>();
            if (!string.IsNullOrEmpty(PublishesOn.Keyword))
            {
                IList<string> SKeywords = PublishesOn.Keyword.Trim().Split(" ");
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
        public User GetUser(int id)
        {
            return _context.Users.Include(o => o.OnModel).Where(u => u.Id == id).SingleOrDefault();
        }
    }
}