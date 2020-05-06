using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _17bnag.Entitys
{
    public class Notitce
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        [Display(Name = "内容")]
        [Required(ErrorMessage = "* 内容不能为空")]
        public string Body { get; set; }
        [Display(Name = "标题：（* 必填）")]
        [Required(ErrorMessage = "* 标题不能为空")]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "* 生效时间不能为空")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "* 过期时间不能为空")]
        public DateTime DateClosed { get; set; }
    }
}
