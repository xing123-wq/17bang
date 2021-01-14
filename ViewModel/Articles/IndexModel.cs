using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Shared;

namespace ViewModel.Articles
{
    public class _SingleItemModel : BaseModel
    {
        public AppraiseManagerModel AppraiseManager { get; set; }
        public _UserModel Author { get; set; }
        public string Abstract { get; set; }
        public string Body { get; set; }
        //public int Bonus { get; set; }
        public int? CategoryId { get; set; }
        public int Comments { get; set; }
        public IList<ArticleAndKeywordModel> Keywords { get; set; }
        public string Title { get; set; }
    }

    public class IndexModel
    {
        public IList<_SingleItemModel> Items { get; set; }
        public int SumOfPages { get; set; }
    }
}
