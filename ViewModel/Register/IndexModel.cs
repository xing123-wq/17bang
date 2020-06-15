using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Register
{
    public class IndexModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Invitation { get; set; }
        public string InvitationCode { get; set; }
        public string SecurityCode { get; set; }
    }
}
