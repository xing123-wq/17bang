using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _17bnag.Entitys
{
    public class Register
    {
        [Display(Name = "邀请人：")]
        [Required(ErrorMessage = "* 邀请人不能为空")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "* 邀请人长度不能小于{2}也不能大于{1}")]
        public string inviter { get; set; }

        [Display(Name = "邀请码：（* 必填）")]
        [RegularExpression("[0-9]*", ErrorMessage = "* 邀请码只能是4位数字")]
        [Required(ErrorMessage = "* 邀请码不能为空")]
        [MaxLength(4)]
        [MinLength(4, ErrorMessage = "* 邀请码只能是4位")]
        public string Invitationcode { get; set; }

        [Display(Name = "验证码:(*必填)")]
        [Required(ErrorMessage = "* 验证码不能为空")]
        [MaxLength(4)]
        [MinLength(4, ErrorMessage = "* 验证码长度只能是4位")]
        public string VerificationCode { get; set; }
    }
}
