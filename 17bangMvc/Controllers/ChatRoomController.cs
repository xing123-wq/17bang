using ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Chat;

namespace _17bangMvc.Controllers
{
    public class ChatRoomController : BaseController
    {
        private ChatRoomService service;
        public ChatRoomController()
        {
            service = new ChatRoomService();
        }
        [HttpGet]
        public ActionResult Index()
        {
            IList<ChatItemModel> model = new List<ChatItemModel>();
            model = service.GetMessages();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(ChatItemModel model)
        {
            return View();
        }
        [HttpGet]
        public ActionResult MessageAssembly()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MessageAssembly(ChatItemModel model)
        {
            service.Save(model);
            return View();
        }
      
    }
}
