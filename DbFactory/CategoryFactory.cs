using BLL;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFactory
{
    public class CategoryFactory
    {
        public static Category series1, series2, series3;

        public static void Create()
        {
            series1 = Inserterd(Global.category_title, Global.category_body, Global.Time.AddDays(-1), null, ArticleFactory.Articles_1, RegisterFactory.at);
            series2 = Inserterd(Global.category_title, Global.category_body, Global.Time.AddDays(-2), series1, null, RegisterFactory.at);
            series3 = Inserterd(Global.category_title, Global.category_body, Global.Time.AddDays(-3), series2, null, RegisterFactory.at);

        }
        public static Category Inserterd(string title, string body, DateTime time, Category parent, IList<Article> articles, Users users)
        {
            Category category = new Category
            {
                Title = title,
                Body = body,
                CreateTime = time,
                Parent = parent,
                Articles = articles,
                Author = users
            };

            new CategoryRepository(Global.context).Add(category);

            return category;
        }

    }
}
