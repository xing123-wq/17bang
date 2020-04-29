using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bnag.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bnag.Pages.Suggest
{
    public class NewModel : PageModel
    {
        public SuggestModel Suggest { get; set; }
        public void OnGet()
        {
            ViewData["title"] = "意见建议——一起帮";
        }
    }
}