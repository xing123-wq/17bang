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
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
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
        public User GetUser(int id)
        {
            return _context.Users.Include(o => o.OnModel).Where(u => u.Id == id).SingleOrDefault();
        }
    }
}