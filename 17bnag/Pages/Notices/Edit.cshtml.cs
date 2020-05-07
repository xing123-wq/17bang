using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bnag.Data;
using _17bnag.Entitys;
using _17bnag.Layout;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bnag.Pages.Notices
{
    [BindProperties]
    public class EditModel : _LayoutModel
    {
        public EditModel(_17bnagContext context) : base(context)
        {
            _context = context;
        }

        public Notitce Notitce { get; set; }

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
            int Id = Convert.ToInt32(Request.RouteValues["id"]);
            int userId = Convert.ToInt32(Request.Cookies[Helper.Const.USER_ID]);
            Notitce.Id = Id;
            Notitce.AuthorId = userId;
            _context.Notitces.Update(Notitce);
            _context.SaveChanges();
            return Redirect("/Notices/index");
        }

        public Notitce GetNotitce(int Id)
        {
            return _context.Notitces.Where(n => n.Id == Id).SingleOrDefault();
        }
    }
}