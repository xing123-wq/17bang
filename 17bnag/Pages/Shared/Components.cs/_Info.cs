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
            int id = Convert.ToInt32(Request.Cookies[Const.USER_ID]);
            User user = _context.Users.Where(u => u.Id == id).Include(u => u.OnModel).SingleOrDefault();
            return View("_Info", user);
        }
    }
}
