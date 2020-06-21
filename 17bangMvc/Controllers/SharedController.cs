using _17bangMvc.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17bangMvc.Controllers
{
    public class SharedController : Controller
    {
        [ChildActionOnly]
        public PartialViewResult _Advertising()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public PartialViewResult _Article()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public PartialViewResult _Keyword()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public PartialViewResult _RankingList()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public PartialViewResult _LogOn()
        {
            
            return PartialView();
        }
    }
}