using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Chat : BaseEntity
    {
        public DateTime PublishTime { get; set; }
        public string Content { get; set; }
        public User Author { get; set; }
        public int? ChatWithId { get; set; }
        public Chat Reply { get; set; }
    }
}
