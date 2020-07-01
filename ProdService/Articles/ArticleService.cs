using BLL;
using Repositorys;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Article;

namespace ProdService.Articles
{
    public class ArticleService : BaseService, IArticleService
    {
        private ArticleRepository repository;
        public ArticleService()
        {
            repository = new ArticleRepository(context);
        }
        public IList<IndexModel> GetBy(int sum)
        {
            IList<Article> articles = repository.GetArticles(sum);
            return mapper.Map<IList<IndexModel>>(articles);
        }

        public int Save(NewModel model)
        {
            Article article = mapper.Map<Article>(model);
            article.Author = GetByCurrentUser();
            article.PublishTime = DateTime.Now;
            repository.Add(article);
            return article.Id;
        }
    }
}
