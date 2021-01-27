using System.Collections.Generic;
using System.ComponentModel;
using Validation;
using ViewModel.Shared;

namespace ViewModel.Category
{
    public class ManageModel : BaseModel
    {
        public IList<SeriesItemMdodel> Items { get; set; }
        public InputModel Input { get; set; }

    }
    public class _SubManageModel
    {
        public SeriesItemMdodel Current { get; set; }
        public IList<SeriesItemMdodel> Children { get; set; }
    }
    public class InputModel : BaseModel
    {
        public IList<SeriesItemMdodel> Categories { get; set; }
        public int? SelectedCategoryId { get; set; }

        [AtRequiredAttrbute]
        [DisplayName("名称")]
        [AtStringLengthAttrbute(25)]
        public string Name { get; set; }

        [DisplayName("描述")]
        [AtStringLengthAttrbute(25)]
        public string Description { get; set; }
    }

    public class SeriesItemMdodel : BaseModel
    {
        public _UserModel Owner { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }
        public bool IsDefault { get; set; }
    }
}
