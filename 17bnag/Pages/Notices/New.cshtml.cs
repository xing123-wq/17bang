using System;
using System.Collections.Generic;
using System.Linq;
using _17bnag.Entitys;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _17bnag.Layout;
using _17bnag.Data;

namespace _17bnag.Pages.Notices
{
    [BindProperties]
    public class NewModel : _LayoutModel
    {
        public NewModel(_17bnagContext context) : base(context)
        {
            _context = context;
        }

        public Notitce Notitce { get; set; }
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
            _context.Notitces.Add(Notitce);
            Notitce.AuthorId = Convert.ToInt32(Request.Cookies[Helper.Const.USER_ID]);
            _context.SaveChanges();
            return Redirect("/Notices");
        }
    }
}