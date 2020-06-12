using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _17bnag.Model.Log
{
    [BindProperties]
    public class OnModel
    {
        public int Id { get; set; }
        [Display(Name = "邀请人(* 必填)")]
        [Required(ErrorMessage = "* 邀请人不能为空")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "* 用户名长度不能小于{2}也不能大于{1}")]
        public string inviter { get; set; }
        [Display(Name = "邀请码:（* 必填）")]
        [Required(ErrorMessage = "* 邀请码不能为空")]
        [MaxLength(4, ErrorMessage = "* 邀请码长度最大4位")]
        [RegularExpression("[0-9]*")]
        public string Code { get; set; }
        public DateTime Time { get; set; }
        public int HelpMony { get; set; }
        public int HelpPoint { get; set; }
        public int HelpBeans { get; set; }
    }
}
