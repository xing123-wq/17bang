using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    sealed public class User : ISendMessage, IChat
    {
        private int _reward;
        private string _name;
        private string _password;
        public int Id { get; set; }
        internal TokenManager Manager { get; set; }
        internal int HelpMony { get; set; }
        internal int credit { get; set; }
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
                    Console.WriteLine("奖赏不能为负数!");
                }
                else
                {
                    _reward = value;
                }



            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value == "admin")
                {
                    _name = "系统管理员";
                }
                //else do nothing
            }
        }
        public User(int id, string name)
        {
            Id = id;
            _name = name;
        }
        private string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password.Length < 6)
                {
                    Console.WriteLine("密码不能小于6位!");
                }
            }
        }
        public User Invitedby { get; set; }
        public string Grade { get; set; }//等级属性
        public int HelpMoney { get; internal set; }
        internal void elevaterank(string label, int integral)
        {

        }
        //提升等级的方法
        static void Register()
        {

        }
        static void Login()
        {

        }
        internal void ChangePasword(string data)
        {



        }
        void ISendMessage.send()
        {
            Console.WriteLine("实现ISendMessage接口方法");
        }
        void IChat.send()
        {
            Console.WriteLine("实现IChat接口方法");
        }
    }
}
