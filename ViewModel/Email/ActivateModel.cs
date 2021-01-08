using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ViewModel.Email
{
    public class ActivateModel
    {
        [EmailAddress]
        [DisplayName("Email地址")]
        [Required]
        [Remote("IsDuplicatedOnAddress", "Email", ErrorMessage = "* 该Email已经被激活！")]
        public string Address { get; set; }

        [Required]
        [DisplayName("验证码")]
        [StringLength(4, MinimumLength = 4)]
        public string AuthCode { get; set; }

        public bool IsActive { get; set; }
    }
}
