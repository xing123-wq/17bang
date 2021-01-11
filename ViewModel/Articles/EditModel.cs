using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Ad;
using ViewModel.Category;

namespace ViewModel.Articles
{
    public class EditModel
    {
        public Articles._InputeModel _Inpute { get; set; }
        public IList<_adItmeModel> _Items { get; set; }
        public IList<_SeriesItemMdodel> _Series { get; set; }
    }
}
