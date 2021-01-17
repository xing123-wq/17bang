using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.AdInWidget
{
    public class _ShowModel
    {
        public IList<ShowItemModel> Items { get; set; }
    }

    //TODO: 被重用了，应该被重命名了……
    public class ShowItemModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
    }
}
