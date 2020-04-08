using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class Problem
    {
        //一起帮的求助可以有多个（最多10个）关键字，
        //请为其设置索引器，以便于我们通过其整数下标进行读写。
        //internal User Author { get; set; }
        public string Body { get; set; }
        public int Reward { get; set; }
        public string Title { get; internal set; }
        public List<Keyword> Keywords { get; internal set; }
        public User Author { get; internal set; }
        public DateTime PublishDateTime { get; internal set; }

        public string[] Keyword = {
            "C#", "编程语言",
            "JavaScript", "工具软件",
            "Java", "顾问咨询", "SQL",
            "职场", "法律", ".net"
        };
        public Problem()
        {

        }
        public string this[int Index]
        {
            get { return Keyword[Index]; }
            set { Keyword[Index] = value; }
        }
        //public Problem(string kind) : base(kind) { }
        //public void Publish()
        //{
        //    Author.credit++;
        //    Author.HelpMony -= Reward;
        ////}
        public static void Load(int Id)
        {

        }
        public static void Delete(int id)
        {

        }


    }

}
