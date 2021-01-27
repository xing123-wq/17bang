using System.Collections.Generic;
using ViewModel.Shared.Article;

namespace ViewModel.Shared
{
    public class _ListModel
    {
        public IList<_ItemModel> List { get; set; }
        //TODO: 以后有用
        public int SumOfPages { get; set; }
    }
}
