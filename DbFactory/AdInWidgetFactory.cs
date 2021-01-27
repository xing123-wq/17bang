using BLL;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFactory
{
    class AdInWidgetFactory
    {
        public static AdInWidget widget, widget1, widget2;
        public static void Create()
        {
            widget = Inserted(Global.Yafang_Text, Global.Common_Url, RegisterFactory.at, ArticleFactory.Articles_1);

            widget1 = Inserted(Global.Class_Text, Global.Common_Url, RegisterFactory.at, ArticleFactory.Articles_2);

            widget2 = Inserted(Global.Finger_Text, Global.Common_Url, RegisterFactory.at, ArticleFactory.Articles_3);
        }

        private static AdInWidget Inserted(string title, string url, Users users, IList<Article> articles)
        {
            AdInWidget widget = new AdInWidget
            {
                Title = title,
                Url = url,
                Author = users,
                Articles = articles,
            };

            new BaseRepository<AdInWidget>(Global.context).Add(widget);

            return widget;
        }
    }
}
