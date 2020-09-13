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
            return entities.Include(a => a.Keywords.Select(k => k.Keyword))
                .Include(u => u.Author)
                .OrderByDescending(a => a.PublishTime)
                .ToList();
        }

        public Article GetArticle(int id)
        {
            return entities.Where(a => a.Id == id)
                .Include(a => a.Author)
                .Include(a => a.Keywords.Select(k => k.Keyword))
                .SingleOrDefault();
        }

        public IList<ArticleAndKeyword> GetString(string keyword)
        {
            IList<ArticleAndKeyword> maps = new List<ArticleAndKeyword>();
            if (!string.IsNullOrEmpty(keyword))
            {
                IList<string> SKeywords = keyword.Trim().Split();
                for (int i = 0; i < SKeywords.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(SKeywords[i]))
                    {
                        continue;
                    }
                    ArticleAndKeyword articleMaps = new ArticleAndKeyword { Keyword = new Keyword { Name = SKeywords[i] } };
                    maps.Add(articleMaps);
                }
            }
            return maps;
        }

        public IList<Article> GetByUserId(int id)
        {
            return entities.Include(a => a.Keywords.Select(k => k.Keyword))
                .Include(u => u.Author)
                .OrderByDescending(a => a.PublishTime)
                .Where(a => a.Author.Id == id)
                .ToList();
        }
    }
}
