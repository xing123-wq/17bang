using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class ProblemRepoistory
    {
        public IList<Problem> Get()
        {
            User pk = new User { Id = 1, Name = "彭昆" };
            User at = new User { Id = 1, Name = "阿泰" };
            User cy = new User { Id = 1, Name = "陈元" };
            Keyword sql = new Keyword { Id = 1, Name = "SQL" };
            Keyword java = new Keyword { Id = 2, Name = "JAVA" };
            Keyword CSharp = new Keyword { Id = 3, Name = "C#" };
            Keyword javascript = new Keyword { Id = 4, Name = "JavaScript" };
            Keyword html5 = new Keyword { Id = 5, Name = "HTML5" };
            Keyword css = new Keyword { Id = 6, Name = "CSS" };
            Keyword linq = new Keyword { Id = 7, Name = "Linq" };
            Keyword ajax = new Keyword { Id = 8, Name = "AJAX" };
            //模拟从数据库取数据
            return new List<Problem>
            {
              new Problem
              {
                PublishDateTime = new DateTime(2020, 2, 1),
                Author = pk,
                Reward=12,
                Body = "期望功能：当U盘被拔下后，系统崩溃或者退出。" +
                "经历：之前看到别人做过，按我正常的理解，系统本身会有检查U盘存在与否的功能，" +
                "但是别人并没有这样做，也就是说他并没有动系统的代码，而是直接对程序一通操作，" +
                "然后就加密了。哪位大神有相关经验或者思路，求一个——————……",
                Title = " 如何使用U盘防护系统的运行",
                Keywords = new List<Keyword>
                {
                   sql,java,CSharp
                },

              },
              new Problem
              {
                PublishDateTime = new DateTime(2019, 10, 7),
                Author = at,
                Reward=1,
                Body = "……",
                Title = " 为什么在给变量a赋值后，再使a=a++之后，输出a的值没有变化。",
                Keywords = new List<Keyword>
                {
                   linq,css,ajax
                },

              },
              new Problem
              {
                PublishDateTime = new DateTime(2020, 1, 21),
                Author = cy,
                Reward=22,
                Body = "RT，也不知道描述的清楚不清楚。求一个思路……c",
                Title = " 有一个自定义UI控件，此控件使用在不同的系统中会有不同的呈现，" +
                "之前的做法是各种switch case，阅读代码时让人很难受，另外新创建一个用到此控件的系统，" +
                "要修改代码的地方也多，只要有swich case 的地方都要再加一个case。" +
                "请教一个好一些的方式来处理这个问题，目的是让代码更加清楚",
                Keywords = new List<Keyword>
                {
                    html5,javascript,sql
                },

              }
            };
        }
    }
}
