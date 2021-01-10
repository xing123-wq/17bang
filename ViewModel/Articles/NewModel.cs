using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModel.Ad;
using ViewModel.Category;

namespace ViewModel.Articles
{
    public class NewModel
    {
        public Articles._InputeModel _Inpute { get; set; }
        public IList<_adItmeModel> _Items { get; set; }
        public IList<_SeriesItemMdodel> _Series { get; set; }

    }

    public class _InputeModel : BaseModel
    {

        [Required(ErrorMessage = "* 正文不能为空")]
        [AllowHtml]
        [StringLength(2312412, MinimumLength = 5, ErrorMessage = "* 正文不能小于{2}和大于{1}字")]
        public string Body { get; set; }

        [Required(ErrorMessage = "* 关键字不能为空")]
        public string Keyword { get; set; }

        [Required(ErrorMessage = "* 标题不能为空")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "* 标题不能小于{2}和大于{1}字")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishTime { get; set; }

        [StringLength(115, ErrorMessage = "* 摘要的长度不能大于155")]
        public string Digest { get; set; }

        public int? SeriesId { get; set; }

        [Required(ErrorMessage = "* 链接不能为空")]
        [Url(ErrorMessage = " * URL格式错误")]
        public string Interlinkage { get; set; }

        [Required(ErrorMessage = "* 文本不能为空")]
        public string text { get; set; }
        public int? ADId { get; set; }
    }
}
