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
        public static Series series1, series2, series3;
        static SeriesFactory()
        {
            series1 = new Series
            {
                Author = RegisterFactory.at,
                Describe = "发生的回访电话",
                FatherSeries = null,
                Title = "别的办法",
                Articles = new List<Article> { ArticleFactory.JAVA }
            };
            series2 = new Series
            {
                Author = RegisterFactory.at,
                Describe = "讲课费的 发v",
                FatherSeries = series1,
                Title = "丰富方法v发发发 ",
                Articles = new List<Article> { ArticleFactory.SQL }
            }; series3 = new Series
            {
                Author = RegisterFactory.at,
                Describe = "v大师傅士大夫士大夫撒旦",
                FatherSeries = null,
                Title = "发射点发射点发射点发射点",
                Articles = new List<Article> { ArticleFactory.UI }
            };

        }
    }
}
