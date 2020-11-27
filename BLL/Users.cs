﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Users : BaseEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int? InviterId { get; set; }
        public Users Inviter { get; set; }
        public string InviterCode { get; set; }
        public int WalletId { get; set; }
        public IList<Advertising> Advertisings { get; set; }
        public IList<BanMoney> Wallet { get; set; }
        public IList<Problem> Problems { get; set; }
        public IList<Article> Articles { get; set; }
        public IList<Series> Series { get; set; }
    }
}