using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BanMoney : BaseEntity
    {
        public int? BanCoin { get; set; }
        public DateTime SpendingTime { get; set; }

        public int OwnerId { get; set; }
        public Users Owner { get; set; }

        public BanMoney SetBanMoney(Users user)
        {
            Random random = new Random();
            return new BanMoney { BanCoin = random.Next(1, 10), Owner = user };
        }
    }
}
