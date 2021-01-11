using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Articles;

namespace ServiceInterface.Article
{
    public interface INewArticleService
    {
        int Publish(_SingleItemModel model);

    }
}
