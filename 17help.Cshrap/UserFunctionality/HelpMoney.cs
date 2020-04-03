using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    internal class HelpMoney:Entity<int>
    {
        internal HelpMoney()
        {

        }
        public DateTime Time { get; set; }
        public int usable { get; set; }
        public int frost { get; set; }
        public string kind { get; set; }
        public int change { get; set; }
        public string remark { get; set; }
        public void GainmMony()
        {

        }//怎么获得帮帮币的

        public void Gainkind(string text)
        {

        } //获取帮帮币的种类
        public int Acquirecount(int pickups)
        {

            return pickups;
        }//获得到的帮帮币的数量
        static void Buy()
        {

        }//所购买的帮帮币
        static void Sell()
        {

        }//所出售的帮帮币
        internal void SillHelpMoney()
        {

        }//获得帮帮币的门槛
        public void Purchased()
        {

        }//已购买方法
        public void sale()
        {

        }//卖出
    }

}
