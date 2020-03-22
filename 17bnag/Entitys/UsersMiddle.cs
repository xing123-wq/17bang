using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bnag.Entitys
{
    public class UsersMiddle
    {
        public int UserId { get; set; }
        public User users { get; set; }
        public int HelpReleaseId { get; set; }
        public HelpRelease Help { get; set; }
    }
}
