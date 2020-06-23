using BLL;
using System;
using System.Collections.Generic;
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
    }
}
