using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global
{
    public enum Role
    {
        [Description("登录用户")]
        Logon,
        [Description("文章发布")]
        Blogger,
        [Description("管理员")]
        Admin
    }
}
