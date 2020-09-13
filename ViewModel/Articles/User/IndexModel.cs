using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Articles.User
{
    public class IndexModel
    {
        public IEnumerable<ViewModel.Articles.IndexModel> Articles { get; set; }
        public Users Author { get; set; }

    }
}
