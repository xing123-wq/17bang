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
        public ActionResult MessageAssembly(ChatItemModel model)
        {
            int ChatId = service.Save(model);
            return Redirect($"/ChatRoom/MessageAssembly?{ChatId}");
        }
        [HttpGet]
        public ActionResult MessageAssembly(int id)
        {
            ChatItemModel model = new ChatItemModel();
            model = service.GetMessage(id);
            return View(model);
        }
    }
}
