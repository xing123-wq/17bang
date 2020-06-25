using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FatherSeries : BaseEntity
    {
        public string Title { get; set; }
        public string Describe { get; set; }
        public IList<Series> Series { get; set; }
        public User Author { get; set; }
    }
}
