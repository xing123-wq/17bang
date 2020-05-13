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
        public async Task<IActionResult> OnPost()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            PublishesOn.AuthorId = Convert.ToInt32(Request.Cookies[Helper.Const.USER_ID]);
            PublishesOn.PublishTime = DateTime.Now;
            _context.PublishArticles.Add(PublishesOn);
            await _context.SaveChangesAsync();
            return Redirect("/Article");
        }
    }
}