using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.LogOn
{
    public class IndexModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SecurityCode { get; set; }
        public bool RememberMe { get; set; }
    }
}
