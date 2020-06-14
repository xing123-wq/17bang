using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using _17bnag.Pages;
namespace _17bnag.Entitys
{
    public class HelpRelease
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "标题:(* 必填)")]
        [Required(ErrorMessage = "* 标题不能为空")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "* 标题不能大于{1},不能小于{2}")]
        public string Title { get; set; }

        [Display(Name = "说明(* 必填)")]
        [Required(ErrorMessage = "* 正文不能为空")]
        [StringLength(21113, MinimumLength = 25, ErrorMessage = "* 正文的长度不能小于{2}，大于{1}")]
        public string Body { get; set; }

        [Display(Name = "关键字：（* 使用空格分隔）")]
        [Required(ErrorMessage = "* 关键字不能为空")]
        public IList<KeywordMiddle> Keywords { get; set; }

        [Display(Name = "定向求助：")]
        public string Resort { get; set; }

        [Display(Name = "悬赏")]
        [Required(ErrorMessage = "* 悬赏帮帮币不能为空")]
        [RegularExpression("[0-9]*", ErrorMessage = "* 悬赏帮帮币只能为正整数")]
        public string Moneys { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDateTime { get; set; }

        public int UserId { get; set; }
        public User Users { get; set; }

        //public string Status { get; set; }
    }
}
