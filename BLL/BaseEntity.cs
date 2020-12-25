using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            PublishTime = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime PublishTime { get; set; }
    }
}
