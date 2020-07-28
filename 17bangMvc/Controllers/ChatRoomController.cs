using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Chat;

namespace _17bangMvc.Controllers
{
    public class ChatRoomController : Controller
    {
        [HttpGet]
        public PartialViewResult Index()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Index(FormCollection data, ChatItemModel model)
        {
            model.Content = data["content"].ToString();
            return PartialView(model);
        }
    }
}
