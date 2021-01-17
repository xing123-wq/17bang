using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModel.Ad;
using ViewModel.Category;
using ViewModel.Shared.EditorTemplates;

namespace ViewModel.Articles
{
    public class InputeModel : BaseModel
    {
        [StringLength(255)]
        [DisplayName("摘要")]
        public string Abstract { get; set; }

        //TODO:
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 25)]
        [DisplayName("正文")]
        [AllowHtml]
        public string Body { get; set; }

        public IList<_SeriesItemMdodel> Categories { get; set; }
        public int SelectedCategoryId { get; set; }

        [Required]
        [StringLength(25)]
        [DisplayName("关键字")]
        public string Keywords { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("标题")]
        public string Title { get; set; }

        public AdContentModel AdContent { get; set; }

    }
}
