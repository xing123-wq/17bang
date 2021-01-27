using System.ComponentModel;
using System.Web.Mvc;
using Validation;

namespace ViewModel.Shared
{
    public class CommentBodyModel
    {
        [AllowHtml]
        [AtRequiredAttrbute]
        [DisplayName("正文")]
        public string Content { get; set; }

        public int? ReplyId { get; set; }
    }
}
