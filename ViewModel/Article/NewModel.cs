using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ViewModel.Article
{
    public class NewModel
    {
        [Required(ErrorMessage = "* 正文不能为空")]
        [StringLength(2312412, MinimumLength = 5, ErrorMessage = "* 正文不能小于{2}和大于{1}字")]
        public string Body { get; set; }

        [Required(ErrorMessage = "* 关键字不能为空")]
        public string Keyword { get; set; }
        
        [Required(ErrorMessage = "* 标题不能为空")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "* 标题不能小于{2}和大于{1}字")]
        public string Title { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime PublishTime { get; set; }

        [Required(ErrorMessage = "* 摘要不能为空")]
        [StringLength(115, ErrorMessage = "* 摘要的长度不能大于155")]
        public string Digest { get; set; }

        public string Series { get; set; }

        public IList<SelectListItem> UsedAds { get; set; }

        [Required(ErrorMessage = "* 链接不能为空")]
        [Url(ErrorMessage = " * URL格式错误")]
        public string Interlinkage { get; set; }

        [Required(ErrorMessage = "* 文本不能为空")]
        public string text { get; set; }
    }
}
