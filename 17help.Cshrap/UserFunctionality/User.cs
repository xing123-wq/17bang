using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    sealed public class User : ISendMessage, IChat
    {
        private int _reward;
        private string _name;
        public int Id { get; set; }
        internal TokenManager Manager { get; set; }
        public int? HelpMony { get; set; }
        internal int Credit { get; set; }
        public Comment Comment { get; set; }
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
        public User()
        {
            if (HelpMony != null)
            {

            }
        }
        public string Password
        {
            get
            {
                return Password;
            }
            internal set
            {
                if (Password.Length < 6)
                {
                    Console.WriteLine("密码不能小于6位!");
                }
            }
        }
        public User Invitedby { get; set; }
        public string Grade { get; set; }//等级属性
        internal void Elevaterank(/*string label, int integral*/)
        {

        }
        //提升等级的方法
        public static void Register()
        {

        }
        public static void Login()
        {

        }
        internal void ChangePasword()
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
