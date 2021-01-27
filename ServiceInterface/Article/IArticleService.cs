using Global;
using ViewModel.Articles;
using ViewModel.Shared;
using ViewModel.Shared.Article;

namespace ServiceInterface.Article
{
    public interface IArticleService : IBaseService
    {
        IndexModel Get(Pager pager);
        int Save(InputeModel model, bool hasEdit = false);
        IndexModel Get(int userId, Pager pager);
        _SingleItemModel GetSingle(int id);
        _PreAndNextModel GetPreAndNext(int id, bool inCategory);
        InputeModel Get();
        InputeModel Get(int id);
        _WidgetModel GetWidget(Pager pager);
        _ListModel GetComments(int id, Pager pager);
    }
}
