using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Series : BaseEntity
    {
        public string Title { get; set; }
        public int? SeriesLevelId { set; get; }
        public string Describe { get; set; }
        public Series SeriesLevel { get; set; }
        public User Author { get; set; }
        public IList<Article> Articles { get; set; }
    }
}
