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
    public class ManageModel : BaseModel
    {
        public IList<_ItemMdodel> _Items { get; set; }

    }
    public class _InputModel : BaseModel
    {
        [Required(ErrorMessage = "* 名称不能为空")]
        [MaxLength(25, ErrorMessage = "* 名称的长度不能大于25")]
        [Remote("_IsDuplicatedOnTitle", "Category", ErrorMessage = "* 名称重复，请重新输入")]
        public string Title { get; set; }

        [Required(ErrorMessage = "* 描述不能为空")]
        [MaxLength(25, ErrorMessage = "* 描述的长度不能大于25")]
        [AllowHtml]
        public string Body { get; set; }

        public int? ParentId { get; set; }
        public IList<_ItemMdodel> _Items { get; set; }
    }

    public class _ItemMdodel : BaseModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int ParentId { get; set; }
        public bool IsDefault { get; set; }
    }
}
