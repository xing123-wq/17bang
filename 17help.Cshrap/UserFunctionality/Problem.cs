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
        private int _reward;
        public int Reward
        {
            get
            {
                return _reward;
            }

            set
            {
                _reward = value;
                if (_reward < 0)
                {
                    throw new Exception("参数越界！");
                }
            }
        }
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("标题不能为null或空值");
                }

                _title = value.Trim();
            }
        }
        public List<Keyword> Keywords { get; set; }
        public User Author { get; set; }
        public DateTime PublishDateTime { get; set; }
        private string _title;
        public Problem()
        {

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
