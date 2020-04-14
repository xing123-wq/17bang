using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class Problem : Content
    {
        //一起帮的求助可以有多个（最多10个）关键字，
        //请为其设置索引器，以便于我们通过其整数下标进行读写。
        //internal User Author { get; set; }
        private int _reward;
        public int Reward
        {
            get
            {
                return _reward;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("悬赏不能为负数");
                }
                _reward = value;
            }
        }
        public Problem()
        {

        }
        public Problem(string kind) : base(kind)
        {

        }
        public static void Load(int Id)
        {

        }
        public static void Delete(int id)
        {

        }
    }

}
