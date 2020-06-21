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
        public User Owner { get; set; }
    }
}
