using _17bnag.Data;
using _17bnag.Model.Log;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
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
        public OnModel OnModel { get; set; }
        public IList<HelpRelease> HelpRelease { get; set; }
        public IList<PublishArticle> PublishArticles { get; set; }
        public IList<Notitce> Notitces { get; set; }
        [NotMapped]
        public bool RememberMe { get; set; }
        [NotMapped]
        [Compare("Password", ErrorMessage = "* 密码不相同")]
        [Display(Name = "确认密码：(* 必填)")]
        [Required(ErrorMessage = "* 确认密码不能为空")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "* 密码必须在{2} 和{1}之间")]
        public string ValidatePassword { get; set; }

        [NotMapped]
        [Display(Name = "验证码:")]
        [Required(ErrorMessage = "* 验证码不能为空")]
        [MaxLength(4, ErrorMessage = "* 验证码长度最大4位")]
        public string Verification { get; set; }

    }
}