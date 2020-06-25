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
        public string Describe { get; set; }
        public FatherSeries FatherSeries { get; set; }
        public User Author { get; set; }
    }
}
