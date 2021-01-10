using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Articles
{
    public class IndexModel : BaseModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public IList<ArticleAndKeyword> Keywords { get; set; }
        public DateTime PublishTime { get; set; }
        public Users Author { get; set; }
        public int CategoryId { get; set; }

    }
}
