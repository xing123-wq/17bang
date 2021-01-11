using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Articles;

namespace ViewModel.Shared
{
    public class ArticleAndKeywordModel
    {
        public _KeywordModel _Keyword { get; set; }
        public _SingleItemModel _Article { get; set; }
    }
}
