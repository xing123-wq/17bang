using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Articles
{
    public class IndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Keyword { get; set; }
        public DateTime PublishTime { get; set; }
        public User Author { get; set; }
    }
}
