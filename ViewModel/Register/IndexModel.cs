using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Register
{
    public class IndexModel
    {
        [Display(Name = "用户名：（* 必填）")]
        [Required(ErrorMessage = "* 用户名不能为空")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "* 用户名长度不能小于{2}也不能大于{1}")]
        public string UserName { get; set; }
        [Display(Name = "密码：（* 必填）")]
        [Required(ErrorMessage = "* 密码不能为空")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "* 密码必须在{2} 和{1}之间")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "* 密码不相同")]
        [Display(Name = "确认密码：(* 必填)")]
        [Required(ErrorMessage = "* 确认密码不能为空")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "* 密码必须在{2} 和{1}之间")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "邀请人(* 必填)")]
        [Required(ErrorMessage = "* 邀请人不能为空")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "* 用户名长度不能小于{2}也不能大于{1}")]
        public string Inviter { get; set; }
        [Display(Name = "邀请码:（* 必填）")]
        [Required(ErrorMessage = "* 邀请码不能为空")]
        [MaxLength(4, ErrorMessage = "* 邀请码长度最大4位")]
        [RegularExpression("[0-9]*", ErrorMessage = "邀请码只能是1-9的数字")]
        public string InviterCode { get; set; }
        [Display(Name = "验证码:")]
        [Required(ErrorMessage = "* 验证码不能为空")]
        [MaxLength(4, ErrorMessage = "* 验证码长度最大4位")]
        public string SecurityCode { get; set; }
    }
}
