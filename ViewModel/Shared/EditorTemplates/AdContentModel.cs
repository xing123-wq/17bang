using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ViewModel.AdInWidget;

namespace ViewModel.Shared.EditorTemplates
{
    public class AdContentModel
    {
        public IList<ShowItemModel> History { get; set; }
        public int? SelectedHistory { get; set; }

        public bool Edit { get; set; }

        [Required]
        [DisplayName("文本")]
        [StringLength(30)]
        public string Text { get; set; }

        [Required]
        [DisplayName("链接")]
        //TODO: 为什么这样的话Client Validation不生效呢？
        //[Global.Core.Validation.Url]
        [RegularExpression(@"http(s)?://.*",
            ErrorMessage = "* URL格式错误")]
        public string Url { get; set; }
    }
}
