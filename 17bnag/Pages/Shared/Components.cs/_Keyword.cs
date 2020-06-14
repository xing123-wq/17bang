using _17bnag.Data;
using _17bnag.Entitys;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bnag.Pages.Shared.Components.cs
{
    public class _Keyword : ViewComponent
    {
        private _17bnagContext _context { get; set; }
        public _Keyword(_17bnagContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            IList<Keyword> keywords = _context.Keywords.ToList();
            return View("_Keyword", keywords);
        }
    }
}
