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

namespace _17bnag.Pages.Notices
{
    [BindProperties]
    [LogOnFilter]
    public class EditModel : _LayoutModel
    {
        public Notitce Notitce { get; set; }

        public EditModel(_17bnagContext context) : base(context)
        {
            _context = context;
        }

        public void OnGet()
        {
            int Id = Convert.ToInt32(Request.RouteValues["id"]);
            int userId = Convert.ToInt32(Request.Cookies[Helper.Const.USER_ID]);
            Notitce = GetNotitce(Id);
            ViewData["title"] = Notitce.Title + "-修改";
            base.SetLogOnStatus();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            int userId = Convert.ToInt32(Request.Cookies[Helper.Const.USER_ID]);
            Notitce.AuthorId = userId;
            Notitce.PublishTime = DateTime.Now;
            _context.Notitces.Update(Notitce);
            _context.SaveChanges();
            return Redirect("/index");
        }

        public Notitce GetNotitce(int Id)
        {
            return _context.Notitces.Where(n => n.Id == Id).SingleOrDefault();
        }
    }
}