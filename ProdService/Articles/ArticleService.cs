using BLL;
using ExtensionMethods;
using Global;
using ProdService.Category;
using Repositorys;
using ServiceInterface;
using ServiceInterface.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using ViewModel.Articles;
using ViewModel.Shared.Article;

namespace ProdService.Articles
{
    public class ArticleService : BaseService, IArticleService
    {
        private ArticleRepository repository;
        private ISeriesService series;
        private IAdvertisingService advertising;
        public ArticleService()
        {
            series = new SeriesService();
            advertising = new AdService();
            repository = new ArticleRepository(context);
        }

        public IndexModel Get(Pager pager)
        {
            IndexModel model = new IndexModel();

            var articles = repository.GetArticles();

            model.SumOfPages = pager.GetSumOfPage(articles.Count());

            articles = articles.Paged(pager);

            model.Items = mapper.Map<IList<ViewModel.Articles._SingleItemModel>>(articles);

            return model;
        }

        public IndexModel Get(int userId, Pager pager)
        {
            IndexModel model = new IndexModel();

            IList<Article> articles = repository.GetByUserId(userId);

            articles = articles.Paged(pager);

            model.Items = mapper.Map<IList<ViewModel.Articles._SingleItemModel>>(articles);

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

        public _SingleItemModel GetSingle(int id)
        {
            Article article = repository.GetArticle(id);
            return mapper.Map<_SingleItemModel>(article);
        }
        public _PreAndNextModel GetPreAndNext(int id, bool inCategory)
        {
            _PreAndNextModel model = new _PreAndNextModel();
            Article prevArticle, nextArticle;

            Article current = repository.Find(id);

            if (inCategory)
            {
                prevArticle = current.Previous;
                checkCategorySame(prevArticle, current);

                nextArticle = current.Next;
                checkCategorySame(nextArticle, current);
            }
            else
            {
                prevArticle = repository.GetPre(current);
                nextArticle = repository.GetNext(current);
            }
            model.Pre = mapper.Map<LiteTitleModel>(prevArticle);
            model.Next = mapper.Map<LiteTitleModel>(nextArticle);
            return model;
        }
        private void checkCategorySame(Article a, Article b)
        {
            if (a != null && b != null)
            {
                if (a.Series != b.Series)
                {
                    throw new Exception(
                        $"根据前后关系取到的Article（id={a.Id}），" +
                        $"其Category(id={a.Series.Id})和Article（id={b.Id}）的Category（id={b.Series.Id}）不合");
                }//else nothing: category can NOT be null
            }//else nothing
        }

        public NewModel Get()
        {
            NewModel model = new NewModel
            {
                _Series = series.GetSeries(),
                _Items = advertising.Get()
            };
            return model;
        }

        public EditModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public _WidgetModel GetWidget(Pager pager)
        {
            _WidgetModel model = new _WidgetModel();
            model.Items = mapper.Map<IList<WidgetItemModel>>(
                repository.FindAll()
                .Paged(pager)
                .OrderByDescending(a => a.PublishTime)
                );
            return model;
        }
    }
}
