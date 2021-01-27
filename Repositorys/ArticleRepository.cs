using BLL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class ArticleRepository : BaseRepository<Article>
    {
        public ArticleRepository(SqlContext context) : base(context)
        {
        }


        public Article GetNext(Article current)
        {
            return entities.Where(a => a.Id > current.Id)
                            .OrderBy(a => a.CreateTime)
                            .FirstOrDefault();
        }
        public Article GetPre(Article current)
        {
            return entities.Where(a => a.Id < current.Id)
                .OrderByDescending(a => a.Id).FirstOrDefault();
        }

        public Article GetArticle(int id)
        {
            return entities.Where(a => a.Id == id)
                .Include(a => a.Author)
                .Include(a => a.Keywords.Select(k => k.Keyword))
                .Include(a => a.Category)
                .SingleOrDefault();
        }


        public IList<Article> GetArticles()
        {
            return entities
                .Include(a => a.Keywords.Select(k => k.Keyword))
                .Include(a => a.Category)
                .Include(a => a.Advertising)
                .Include(a => a.Author)
                .ToList();
        }

        public IList<Article> GetByUserId(int id)
        {
            return entities
                .Where(a => a.Author.Id == id).ToList();
        }
    }
}
