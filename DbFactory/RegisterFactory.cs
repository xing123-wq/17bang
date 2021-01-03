﻿using BLL;
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
        public static Users at, wpz, lzb;
        static IEnumerable<Users> users;
        const string password = "1234";
        static RegisterFactory()
        {
            at = new Users
            {
                Name = "阿泰12",
                Password = password.GetMd5Hash(),
                Inviter = at,
                InviterCode = StringExtension.GetRandomNumber(4),
                Role = Role.Admin
            };
            wpz = new Users
            {
                Name = "王胖子",
                Password = password.GetMd5Hash(),
                Inviter = at,
                InviterCode = StringExtension.GetRandomNumber(4)
            };
            lzb = new Users
            {
                Name = "小李头哦",
                Password = password.GetMd5Hash(),
                Inviter = at,
                InviterCode = StringExtension.GetRandomNumber(4),
                Role = Role.Blogger
            };
        }
        public static void Create()
        {
            users = new List<Users>
            {
                at,wpz,lzb

            };
            at.NewSeriers();
            wpz.NewSeriers();
            lzb.NewSeriers();
            new UserRepositroy(Global.context).AddRange(users);
        }
    }
}
