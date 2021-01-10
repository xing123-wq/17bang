using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Articles
{
    public class _PreAndNextModel
    {
        public LiteTitleModel Pre { get; set; }
        public LiteTitleModel Next { get; set; }
    }
    public class LiteTitleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
