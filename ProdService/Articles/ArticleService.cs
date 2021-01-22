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
using ServiceInterface.Article;
using ViewModel.Articles;
using ViewModel.Shared.Article;
using ViewModel.Shared.EditorTemplates;

namespace ProdService.Articles
{
    public class ArticleService : BaseService, IArticleService
    {
        #region constructor 
        private readonly ArticleRepository _repository;
        private readonly ISeriesService _series;
        private readonly IAdvertisingService _advertising;
        public ArticleService()
        {
            _series = new SeriesService();
            _advertising = new AdService();
            _repository = new ArticleRepository(Context);
        }
        #endregion

        #region GetMethod
        public IndexModel Get(Pager pager)
        {
            IndexModel model = new IndexModel();

            var articles = _repository.GetArticles();

            model.SumOfPages = pager.GetSumOfPage(articles.Count());

            articles = articles.Paged(pager);

            model.Items = Mapper.Map<IList<_SingleItemModel>>(articles);

            return model;
        }

        public IndexModel Get(int userId, Pager pager)
        {
            var model = new IndexModel();

            var articles = _repository.GetByUserId(userId);

            articles = articles.Paged(pager);

            model.Items = Mapper.Map<IList<_SingleItemModel>>(articles);

            return model;
        }

        public InputeModel Get()
        {
            InputeModel model = new InputeModel
            {
                Categories = _series.GetSeries(),
                AdContent = new AdContentModel
                {
                    History = _advertising.GetHistory(),
                }
            };
            return model;
        }

        public InputeModel Get(int id)
        {
            var article = _repository.GetArticle(id);

            var input = Mapper.Map<InputeModel>(article);
            input.Categories = _series.GetSeries();
            input.AdContent = new AdContentModel
            {
                History = _advertising.GetHistory()
            };
            for (var i = 0; i < article.Keywords.Count(); i++)
            {
                input.Keywords = string.Concat(article.Keywords[i].Keyword.Name.Split(' '));

            }

            return input;
        }

        public _SingleItemModel GetSingle(int id)
        {
            Article article = _repository.GetArticle(id);
            return Mapper.Map<_SingleItemModel>(article);
        }

        public _PreAndNextModel GetPreAndNext(int id, bool inCategory)
        {
            _PreAndNextModel model = new _PreAndNextModel();
            Article prevArticle, nextArticle;

            var current = _repository.Find(id);

            if (inCategory)
            {
                prevArticle = current.Previous;
                CheckCategorySame(prevArticle, current);

                nextArticle = current.Next;
                CheckCategorySame(nextArticle, current);
            }
            else
            {
                prevArticle = _repository.GetPre(current);
                nextArticle = _repository.GetNext(current);
            }
            model.Pre = Mapper.Map<LiteTitleModel>(prevArticle);
            model.Next = Mapper.Map<LiteTitleModel>(nextArticle);
            return model;
        }

        public _WidgetModel GetWidget(Pager pager)
        {
            _WidgetModel model = new _WidgetModel
            {
                Items = Mapper.Map<IList<WidgetItemModel>>(
                    _repository.FindAll()
                        .Paged(pager)
                        .OrderByDescending(a => a.PublishTime)
                )
            };
            return model;
        }
        #endregion

        public int Save(InputeModel model, bool hasEdit = false)
        {
            Article article;

            if (hasEdit)
            {
                article = _repository.Find(model.Id);
                if (CurrentUserId != article.Author.Id)
                {
                    if (CurrentUserId != null)
                        throw new Exception($"当前用户Id：{CurrentUserId}，不是该文章作者Id：{article.Author.Id}!");
                }
                article.EditOrPublish(model.Keywords);
                article.Author = GetByCurrentUser();
                Mapper.Map(article, model);
                _repository.Update(article);
            }
            else
            {
                article = Mapper.Map<Article>(model);
                article.Author = GetByCurrentUser();
                article.EditOrPublish(model.Keywords);
                _repository.Add(article);
            }
            return article.Id;
        }

        #region private
        private static void CheckCategorySame(Article a, Article b)
        {
            if (a == null || b == null) return;

            if (a.Series != b.Series)
            {
                throw new Exception(
                    $"根据前后关系取到的Article（id={a.Id}），" +
                    $"其Category(id={a.Series.Id})和Article（id={b.Id}）的Category（id={b.Series.Id}）不合");
            }//else nothing: category can NOT be null
        }
        #endregion

    }
}
