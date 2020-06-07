using _17bnag.Data;
using _17bnag.Entitys;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bnag.Pages.Shared.Components.cs
{
    public class _Notice : ViewComponent
    {
        private _17bnagContext _context { get; set; }
        public _Notice(_17bnagContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            IList<Notitce> _notitces = _context.Notitces.OrderByDescending(n => n.PublishTime).ToList();
            
            return View("_Notice", _notitces);
        }
        private void DeleteNotice()
        {

        }
    }
}
