using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _17bnag.Entitys
{
    public class PublishArticle
    {
        public int Id { get; set; }
        public User Author { get; set; }
        public int AuthorId { get; set; }

        [Display(Name = "内容：（* 必填）")]
        [Required(ErrorMessage = "* 正文不能为空")]
        [StringLength(2312412, MinimumLength = 5, ErrorMessage = "* 正文不能小于{2}和大于{1}字")]
        public string Body { get; set; }

        [Display(Name = "关键字：（* 必填）")]
        [Required(ErrorMessage = "* 关键字不能为空")]
        [NotMapped]
        public string Keyword { get; set; }

        public IList<ArticleMap> keywords { get; set; }

        [Display(Name = "标题：（* 必填）")]
        [Required(ErrorMessage = "* 标题不能为空")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "* 标题不能小于{2}和大于{1}字")]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishTime { get; set; }

        [Display(Name = "摘要：（* 建议填写）")]
        [Required(ErrorMessage = "* 摘要不能为空")]
        [StringLength(115, ErrorMessage = "* 摘要的长度不能大于155")]
        public string Digest { get; set; }

        [Display(Name = "添加到系列：")]
        public string Series { get; set; }

        [Display(Name = "之前用过的广告：")]
        public string UsedAds { get; set; }

        [Display(Name = "链接：（* 必填）")]
        [Required(ErrorMessage = "* 链接不能为空")]
        [Url(ErrorMessage = " * URL格式错误")]
        public string Interlinkage { get; set; }

        [Display(Name = "文字内容：（* 必填）")]
        [Required(ErrorMessage = "* 文本不能为空")]
        public string text { get; set; }
    }
}
