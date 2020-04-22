using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bnag.Pages;
using System.Reflection;
using System.ComponentModel;

namespace _17bnag.Helper
{
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
