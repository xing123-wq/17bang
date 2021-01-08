using ExtensionMethods;
using Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Email : BaseEntity
    {
        public int ActiveCount { get; set; }
        public string Address { get; set; }
        public string AuthCode { get; protected internal set; }
        public bool IsActive { get; set; }
        /// <summary>
        /// 仅在手工点击发送验证Email时调用
        /// </summary>
        public void Send()
        {
            AuthCode = StringExtension.GetRandomNumber(4);
            EmailHelper.SendAddressValidate(Address, AuthCode);
        }

    }
}
