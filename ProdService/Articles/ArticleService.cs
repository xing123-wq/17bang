using BLL;
using ExtensionMethods;
using Global;
using Repositorys;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using ViewModel.Articles;

namespace ProdService.Articles
{
    public class ArticleService : BaseService, IArticleService
    {
        private ArticleRepository repository;
        public ArticleService()
        {
            repository = new ArticleRepository(context);
        }

        public IList<ViewModel.Articles.IndexModel> GetBy(int sum)
        {
            IList<Article> articles = repository.GetArticles(sum);
            return mapper.Map<IList<ViewModel.Articles.IndexModel>>(articles);
        }

        public IList<ViewModel.Articles.IndexModel> Get(int Id)
        {
            IList<Article> articles = repository.GetByUserId(Id);
            return mapper.Map<IList<ViewModel.Articles.IndexModel>>(articles);
        }

        public ViewModel.Articles.User.IndexModel GetCurrentArticle(Pager pager, int Id)
        {
            ViewModel.Articles.User.IndexModel model = new ViewModel.Articles.User.IndexModel();
            model.Articles = Select.Get(Get(Id), pager.PageIndex, Const.PAGE_SIZE);
            model.Author = GetByCurrentUser();
            return model;
        }

        public int Save(_InputeModel model)
        {
            Article article = mapper.Map<Article>(model);
            article.Author = GetByCurrentUser();
            article.Publish(model.Keyword);
            repository.Add(article);
            return article.Id;
        }

        public IndexModel GetSingle(int id)
        {
            Article article = repository.GetArticle(id);
            return mapper.Map<IndexModel>(article);
        }
        public _PreAndNextModel GetPreAndNext(int id)
        {
            _PreAndNextModel model = new _PreAndNextModel();

            Article current = repository.Find(id);

            model.Pre = mapper.Map<LiteTitleModel>(repository.GetPre(current));
            model.Next = mapper.Map<LiteTitleModel>(repository.GetNext(current));

            return model;
        }
    }
}
