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

namespace _17bnag
{
    public class DeleteModel : _LayoutModel
    {
        public DeleteModel(_17bnagContext context) : base(context)
        {
            _context = context;
        }
        [BindProperty]
        public HelpRelease help { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            help = await _context.HelpRelease.FirstOrDefaultAsync(m => m.Id == id);

            if (help == null)
            {
                return NotFound();
            }
            base.SetLogOnStatus();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            help = await _context.HelpRelease.FindAsync(id);

            if (help != null)
            {
                _context.HelpRelease.Remove(help);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Problem", new { id = 1 });
        }
    }
}