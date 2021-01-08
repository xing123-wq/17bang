using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
    public enum EmailValidationResult
    {
        HasSend = 1,
        Duplicated = 2
    }
    public static class EnumExtension
    {
        public static string GetDescription<T>(this T value)
        {
            Type enumType = typeof(T);
            FieldInfo enumfieldInfo = enumType.GetField(value.ToString());
            DescriptionAttribute attribute = (DescriptionAttribute)
                DescriptionAttribute.GetCustomAttribute(enumfieldInfo, typeof(DescriptionAttribute));
            return attribute.Description;
        }
    }
}
