﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPage
{
    public class ProblemModel : PageModel
    {
        public void OnGet()
        {
            ViewData["title"] = "首页-一起帮";
        }
    }
}