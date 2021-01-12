using BLL;
using Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Articles;
using ViewModel.Shared.Article;

namespace ServiceInterface
{
    public interface IArticleService : IBaseService
    {
        IndexModel Get(Pager pager);
        int Save(_InputeModel model, bool HasEdit = false);
        IndexModel Get(int userId, Pager pager);
        _SingleItemModel GetSingle(int id);
        _PreAndNextModel GetPreAndNext(int id, bool inCategory);
        NewModel Get();
        NewModel Get(int id);
        _WidgetModel GetWidget(Pager pager);
    }
}
