using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bnag.Data;
using _17bnag.Filter;
using _17bnag.Layout;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace _17bnag.Pages
{
    public class IndexModel : _LayoutModel
    {
        public IndexModel(_17bnagContext context) : base(context)
        {
        }
        
        public void OnGet()
        {
            base.SetLogOnStatus();
            ViewData["title"] = "首页-一起帮";
        }
    }
}
