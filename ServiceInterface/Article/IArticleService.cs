using BLL;
using Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Articles;

namespace ServiceInterface
{
    public interface IArticleService : IBaseService
    {
        IList<ViewModel.Articles.IndexModel> GetBy(int sum);
        int Save(_InputeModel model);
        ViewModel.Articles.User.IndexModel GetCurrentArticle(Pager pager, int Id);
        IndexModel GetSingle(int id);
        _PreAndNextModel GetPreAndNext(int id);
    }
}
