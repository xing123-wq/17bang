using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bnag.Data;
using _17bnag.Layout;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bnag.Pages.Message
{
    public class MineModel : _LayoutModel
    {
        public MineModel(_17bnagContext context) : base(context)
        {
        }

        public void OnGet()
        {
            ViewData["title"] = "我的消息-一起帮";
            base.SetLogOnStatus();
        }
    }
}