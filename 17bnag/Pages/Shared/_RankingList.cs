using _17bnag.Data;
using _17bnag.Entitys;
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
            IList<User> Users = _context.Users.OrderByDescending(u => u.Time).ToList();
            //_RankingList _RankingListModel = new _RankingList(_context);
            return View("_RankingList", Users);
        }
    }
}
