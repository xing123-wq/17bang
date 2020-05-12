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
    [LogOnFilter]
    public class EditModel : _LayoutModel
    {
        public EditModel(_17bnagContext context) : base(context)
        {
            _context = context;
        }
        [BindProperty]
        public HelpRelease help { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
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
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            help.PublishDateTime = DateTime.Now;
            _context.Attach(help).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(help.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("/Problem", new { id = 1 });
        }

        private bool MovieExists(int id)
        {
            return _context.HelpRelease.Any(e => e.Id == id);
        }
    }
}