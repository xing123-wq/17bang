using _17bnag.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bnag.Pages.Shared
{
    public class _RankingList : ViewComponent
    {
        private _17bnagContext _context { get; set; }
        public _RankingList(_17bnagContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View("_RankingList");
        }
    }
}
