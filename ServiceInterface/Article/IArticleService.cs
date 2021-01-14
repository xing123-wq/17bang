using Global;
using ViewModel.Articles;
using ViewModel.Shared.Article;

namespace ServiceInterface.Article
{
    public interface IArticleService : IBaseService
    {
        IndexModel Get(Pager pager);
        int Save(_InputeModel model, bool HasEdit = false);
        IndexModel Get(int userId, Pager pager);
        _SingleItemModel GetSingle(int id);
        _PreAndNextModel GetPreAndNext(int id, bool inCategory);
        _InputeModel Get();
        _InputeModel Get(int id);
        _WidgetModel GetWidget(Pager pager);
    }
}
