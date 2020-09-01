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
        IList<IndexModel> GetBy(int sum);
        int Save(NewModel model);

    }
}
