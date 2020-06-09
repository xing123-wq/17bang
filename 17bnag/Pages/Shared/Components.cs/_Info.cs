using _17bnag.Data;
using _17bnag.Entitys;
using _17bnag.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bnag.Pages.Shared.Components.cs
{
    public class _Info : ViewComponent
    {
        private _17bnagContext _context { get; set; }
        public _Info(_17bnagContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            string name =ViewData[Const.USER_NAME].ToString();
            User user = _context.Users.Where(u => u.Name == name).Include(u => u.OnModel).SingleOrDefault();
            return View("_Info", user);
        }
    }
}
