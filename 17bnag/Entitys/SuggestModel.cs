using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _17bnag.Entitys
{
    public class SuggestModel
    {
        public int Id { get; set; }
        [Display(Name = "描述：")]
        public string Body { get; set; }
        [Display(Name = "标题：（* 必填）")]
        [Required(ErrorMessage = "* 标题不能为空")]
        [MinLength(4, ErrorMessage = ("* 长度不能小于4"))]
        [MaxLength(250, ErrorMessage = "* 最多250字")]
        public string Title { get; set; }
    }
}
