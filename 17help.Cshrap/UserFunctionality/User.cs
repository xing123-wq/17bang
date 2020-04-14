using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    sealed public class User : ISendMessage, IChat
    {
        private string _name;
        public int Id { get; set; }
        internal TokenManager Manager { get; set; }
        public int? HelpMony { get; set; }
        internal int Credit { get; set; }
        public List<Problem> Problems { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Article> Articles { get; set; }
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
                _name = value;
            }
        }
        public User()
        {
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

        public void send()
        {
            throw new NotImplementedException();
        }
    }
}
