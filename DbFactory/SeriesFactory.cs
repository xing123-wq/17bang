using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFactory
{
    public class SeriesFactory
    {
        public static Category series1, series2, series3;
        static SeriesFactory()
        {
            series1 = new Category
            {
                Author = RegisterFactory.at,
                Body = "发生的回访电话",
                Title = "别的办法",
                PublishTime = Global.Time.AddDays(-1),
                Articles = new List<Article> { ArticleFactory.JAVA },
                Parent = series1
            };
            series2 = new Category
            {
                Author = RegisterFactory.at,
                Body = "讲课费的 发v",
                Parent = series1,
                Title = "丰富方法v发发发 ",
                Articles = new List<Article> { ArticleFactory.SQL
    },
                PublishTime = Global.Time.AddDays(-1)
            };
            series3 = new Category
            {
                Author = RegisterFactory.at,
                Body = "v大师傅士大夫士大夫撒旦",
                Parent = series2,
                Title = "发射点发射点发射点发射点",
                PublishTime = Global.Time.AddDays(-1),
                Articles = new List<Article> { ArticleFactory.UI },
            };

        }
    }
}
