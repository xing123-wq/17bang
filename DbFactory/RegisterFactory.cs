using BLL;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFactory
{
    public class RegisterFactory : BaseFactory
    {
        static User at12, fg12;
        internal void Create()
        {
            at12 = new User
            {
                Id = 1,
                Name = "阿泰12",
                Inviter = fg12,
                InviterCode = "1234",
            };
            fg12 = new User
            {
                Id = 2,
                Name = "飞哥12",
                Inviter = at12,
                InviterCode = "1234"
            };

            IEnumerable<User> users = new List<User>
            {
                at12,fg12
            };
            new UserRepositroy(context).AddRange(users);
        }
    }
}

