using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ArticleAndKeyword : BaseEntity
    {
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
        public int KeywordId { get; set; }
        public virtual Keyword Keyword { get; set; }
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
    }

}
