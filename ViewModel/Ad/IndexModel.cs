using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Ad
{
    public class IndexModel : BaseModel
    {
        [Required(ErrorMessage = "* 文本不能为空")]
        [MaxLength(30, ErrorMessage = "* 文本的长度不能大于30")]
        public string Title { get; set; }

        [Required(ErrorMessage = "* 链接不能为空")]
        [Url(ErrorMessage = "* URL格式错误")]
        public string Url { get; set; }
        public IList<IndexModel> ADS { get; set; }
        public IndexModel AD { get; set; }
    }
}
