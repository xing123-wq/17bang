using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class StringExtension
    {
        public static string GetMd5Hash(this string input)
        {
            return getmd5(getmd5(input + "17@bang"));
        }
        private static string getmd5(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));//x2:转换成16进制
                }
                return sBuilder.ToString();
            }
        }
        static Random random = new Random();
        private static char[] constant = "1234567890qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM".ToArray();
        public static string GetRandomNumber(int length)
        {
            StringBuilder newRandom = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                newRandom.Append(constant[random.Next(constant.Length)]);
            }
            return newRandom.ToString();
        }
    }
}
