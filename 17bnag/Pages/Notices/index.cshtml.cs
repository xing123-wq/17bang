using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _17bnag.Entitys;
using _17bnag.Layout;
using _17bnag.Data;
using Microsoft.EntityFrameworkCore;

namespace _17bnag.Pages.Notices
{
    public class indexModel : _LayoutModel
    {
        public indexModel(_17bnagContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Notitce> Notitces { get; set; }
        public void OnGet()
        {
            Notitces = _context.Notitces.Include(h => h.Author).ToList();
            base.SetLogOnStatus();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return Page();
        }
    }
}