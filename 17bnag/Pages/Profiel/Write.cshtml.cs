using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bnag.Data;
using _17bnag.Layout;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bnag.Profiel
{
    [BindProperties]
    public class WriteModel : _LayoutModel
    {
        public WriteModel(_17bnagContext context) : base(context)
        {
        }

        public bool? IsFemale { get; set; }
        public void OnGet()
        {
            base.SetLogOnStatus();
            ViewData["title"] = "个人资料--一起帮";
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