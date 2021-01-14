using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public abstract class Content : BaseEntity
    {
        public Users Author { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }

        public virtual void Publish()
        {
            if (this.Author == null)
            {
                throw new Exception(string.Format($"作者不能为空，{GetType().Name}"));
            }
      
        }

        public virtual void Edit()
        {

        }
    }
}
