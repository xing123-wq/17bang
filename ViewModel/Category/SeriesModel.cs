using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ViewModel.Category
{
    public class SeriesModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "* 名称不能为空")]
        [MaxLength(25, ErrorMessage = "* 名称的长度不能大于25")]
        public string Title { get; set; }

        [Required(ErrorMessage = "* 描述不能为空")]
        [MaxLength(25, ErrorMessage = "* 描述的长度不能大于25")]
        public string Body { get; set; }
        public int? SeriesLevelId { get; set; }
        public SeriesModel SeriesLevel { get; set; }
        public IList<Article> Articles { get; set; }
        public IList<SeriesModel> SeriesModels { get; set; }
        public IEnumerable<SelectListItem> SelectLists { get; set; }
    }
}
