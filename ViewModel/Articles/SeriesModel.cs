using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ViewModel.Articles
{
    public class SeriesModel
    {
        [Required(ErrorMessage = "* 名称不能为空")]
        [MaxLength(25, ErrorMessage = "* 名称的长度不能大于25")]
        public string Title { get; set; }

        [Required(ErrorMessage = "* 描述不能为空")]
        [MaxLength(255, ErrorMessage = "* 描述的长度不能大于255")]
        public string Body { get; set; }
        public Series Series { get; set; }
        public IEnumerable<SelectListItem> Serieses { get; set; }
    }
}
