using BLL;
using ExtensionMethods;
using Global;
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
        public RegisterFactory()
        {
            InviterCode = StringExtension.GetRandom(4);
        }
        public static Users at, wpz, lzb, lw, ht;

        static string password = "1234".GetMd5Hash();

        int InviterCode;
        public static void Create()
        {
            RegisterFactory Register = new RegisterFactory();

            at = Inserter("阿泰12", password, null, Register.InviterCode, Role.Admin);

            wpz = Inserter("王大胖子", password, at, Register.InviterCode);

            lzb = Inserter("小李头哦", password, wpz, Register.InviterCode, Role.Blogger);

            lw = Inserter("阿伟12", password, at, Register.InviterCode);

            ht = Inserter("胡豆豆1", password, at, Register.InviterCode);

        }

        public static Users Inserter(string name, string password, Users Inviter, int code, Role role = Role.Logon)
        {
            Users users = new Users
            {
                Name = name,
                Password = password,
                Inviter = Inviter,
                InviterCode = code,
                Role = role,
            };

            users.NewSeriers();

            new UserRepositroy(Global.context).Add(users);
            return users;
        }

    }
}
