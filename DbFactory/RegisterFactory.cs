using BLL;
using ExtensionMethods;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFactory
{
    public class RegisterFactory
    {
        public static User at, wpz, lzb;
        static IEnumerable<User> users;
        const string password = "1234";
        static RegisterFactory()
        {
            at = new User
            {
                Name = "阿泰12",
                Password = password.GetMd5Hash(),
                Inviter = at,
                InviterCode = StringExtension.GetRandomNumber(4),
            };
            wpz = new User
            {
                Name = "王胖子",
                Password = password.GetMd5Hash(),
                Inviter = at,
                InviterCode = StringExtension.GetRandomNumber(4)
            };
            lzb = new User
            {
                Name = "小李头哦",
                Password = password.GetMd5Hash(),
                Inviter = at,
                InviterCode = StringExtension.GetRandomNumber(4)
            };
        }
        public static void Create()
        {
            users = new List<User>
            {
                at,wpz,lzb

            };
            new UserRepositroy(Global.context).AddRange(users);
        }
    }
}
