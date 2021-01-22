using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ViewModel.Category;
using ViewModel.Shared.EditorTemplates;
using Validation;

namespace ViewModel.Articles
{
    public class InputeModel : BaseModel
    {
        [AtStringLengthAttrbute(255)]
        [DisplayName("摘要")]
        public string Abstract { get; set; }

        [AtRequiredAttrbute]
        [AtStringLengthAttrbute(int.MaxValue, MinimumLength = 25)]
        [DisplayName("正文")]
        [AllowHtml]
        public string Body { get; set; }

        public IList<SeriesItemMdodel> Categories { get; set; }
        public int SelectedCategoryId { get; set; }

        [AtRequiredAttrbute]
        [AtStringLengthAttrbute(25)]
        [DisplayName("关键字")]
        public string Keywords { get; set; }

        [AtRequiredAttrbute]
        [AtStringLengthAttrbute(255)]
        [DisplayName("标题")]
        public string Title { get; set; }

        public AdContentModel AdContent { get; set; }

    }
}
