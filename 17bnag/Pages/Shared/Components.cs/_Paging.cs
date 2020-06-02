using _17bnag.Data;
using _17bnag.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bnag.Pages.Shared.Components.cs
{
    public class _Paging: ViewComponent
    {
        private _17bnagContext _context { get; set; }
        public int Sum { get; set; }
        public _Paging(_17bnagContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(IEnumerable<object> data)
        {
            Sum = ExtensionMethod.GetSum(data);
            return View("_Paging",Sum);
        }
    }
}
