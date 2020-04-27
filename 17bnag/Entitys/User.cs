using _17bnag.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _17bnag.Entitys
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "用户名：（* 必填）")]
        [Required(ErrorMessage = "* 用户名不能为空")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "* 用户名长度不能小于{2}也不能大于{1}")]
        public string Name { get; set; }

        [Display(Name = "密码：（* 必填）")]
        [Required(ErrorMessage = "* 密码不能为空")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "* 密码必须在{2} 和{1}之间")]
        public string Password { get; set; }
        public int HelpMony { get; set; }
        public DateTime Time { get; set; }
        [Display(Name = "邀请码：（* 必填）")]
        [RegularExpression("[0-9]*", ErrorMessage = "* 邀请码只能是4位数字")]
        [Required(ErrorMessage = "* 邀请码不能为空")]
        [MaxLength(4)]
        [MinLength(4, ErrorMessage = "* 邀请码只能是4位")]
        public string Invitationcode { get; set; }
        [Display(Name = "邀请人：")]
        [Required(ErrorMessage = "* 邀请人不能为空")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "* 邀请人长度不能小于{2}也不能大于{1}")]
        public string inviter { get; set; }

        [Display(Name = "验证密码：（* 必填）")]
        [Required(ErrorMessage = "* 确认密码不能为空")]
        [Compare("Password", ErrorMessage = "* 确认密码和密码不一致")]
        public string ValidatePassword { get; set; }

        [Display(Name = "验证码:(*必填)")]
        [Required(ErrorMessage = "* 验证码不能为空")]
        [MaxLength(4)]
        [MinLength(4, ErrorMessage = "* 验证码长度只能是4位")]
        public string VerificationCode { get; set; }
        public IList<HelpRelease> HelpRelease { get; set; }
        public IList<PublishArticle> PublishArticles { get; set; }
    }
}