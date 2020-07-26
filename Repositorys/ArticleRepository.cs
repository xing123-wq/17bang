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
        public ArticleRepository(SQLContext context) : base(context)
        {
        }
        public IList<Article> GetArticles(int sum)
        {
            return entities.Include(a => a.Keywords.Select(k => k.Keyword)).Include(u => u.Author).ToList();
        }
        public Article GetArticle(int id)
        {
            return entities.Where(a => a.Id == id).SingleOrDefault();
        }
    }
}
