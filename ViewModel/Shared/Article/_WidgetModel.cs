using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Shared.Article
{
    public class _WidgetModel
    {
        public IList<WidgetItemModel> Items { get; set; }
    }

    public class WidgetItemModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
