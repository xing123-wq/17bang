using _17bnag.Data;
using _17bnag.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bnag.Pages.Shared
{
    public class _UserRegister : ViewComponent
    {
        private _17bnagContext _context { get; set; }
        public _UserRegister(_17bnagContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            IList<User> Users = _context.Users.Include(u => u.OnModel).OrderByDescending(o => o.OnModel.Time).ToList();
            return View("_UserRegister", Users);
        }
    }
}
