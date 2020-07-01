using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Article
{
    public class IndexModel
    {
        public string Title { get; set; }
        public string Body { get; set; }

        public string Keyword { get; set; }
        public string Author { get; set; }
        public string Abstract { get; set; }
    }
}
