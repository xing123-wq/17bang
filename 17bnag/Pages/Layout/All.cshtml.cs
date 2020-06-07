using System;
using System.Collections.Generic;
using System.Linq;
using _17bnag.Data;
using _17bnag.Entitys;
using _17bnag.Helper;
using _17bnag.Log;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bnag.Layout
{
    public class _LayoutModel : PageModel
    {
        public _17bnagContext _context { get; set; }
        public _LayoutModel(_17bnagContext context)
        {
            _context = context;
        }
        public _LayoutModel()
        {

        }
        public virtual void SetLogOnStatus()
        {
            bool hasUserId = Request.Cookies.TryGetValue(Const.USER_ID, out string userId);
            bool hasPassword = Request.Cookies.TryGetValue(Const.USER_PASSWORD, out string password);
            User user = Load(Convert.ToInt32(userId));
            if (hasUserId)
            {
                if (user != null)
                {
                    if (user.Password.GetMd5Hash() == password)
                    {
                        ViewData[Const.USER_NAME] = user.Name;
                    }
                }
            }
        }

        public User Load(int id)
        {
            //模拟的方法
            return _context.Users.Where(u => u.Id == id).SingleOrDefault();
        }
    }
}
