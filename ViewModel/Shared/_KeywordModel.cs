using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Articles;

namespace ViewModel.Shared
{
    public class _KeywordModel : BaseModel
    {
        public string Name { get; set; }
        public IList<ArticleAndKeywordModel> articles { get; set; }
    }
}
