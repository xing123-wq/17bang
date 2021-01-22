using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public Users Author { get; set; }
        public Category Parent { get; set; }
        public bool IsDefault { get; set; }
        public IList<Article> Articles { get; set; }

        public virtual void SetParent(Category parent)
        {
            if (parent == this)
            {
                throw new ArgumentException(
                    $"Category（id={this.Id}）的Parent（id={parent.Id}）不能是自己");
            }
            Parent = parent;
        }
    }
}
