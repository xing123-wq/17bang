using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModel.Category;

namespace ServiceInterface.Category
{
    public interface ISeriesService : IBaseService
    {
        int Save(SeriesModel model);
        IList<SeriesModel> Get(int userId);
        IEnumerable<SelectListItem> GetSelectListItems(IList<SeriesModel> source);
    }
}
