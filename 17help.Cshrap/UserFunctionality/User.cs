﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    sealed public class User : Entity, ISendMessage, IChat
    {
        internal User(string inviter)
        {

        }
        public User()
        {

        }
        internal TokenManager Manager { get; set; }
        internal int HelpMony { get; set; }
        internal int credit { get; set; }
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
                    Console.WriteLine("奖赏不能为负数!");
                }
                else
                {
                    _reward = value;
                }



            }
        }
        public string Name;
        public string _name
        {
            get
            {
                return Name;
            }
            set
            {
                if (value == "admin")
                {
                    Name = "系统管理员";
                }
                else
                {
                    Console.WriteLine("不是系统管理员");
                }
            }
        }
        private string _Password;
        private string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                if(_Password.Length<6)
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