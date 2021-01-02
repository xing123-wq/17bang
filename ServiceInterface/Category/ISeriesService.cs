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
        int Save(_InputModel model, bool HasEidt = false);
        ManageModel Get();
        IList<_SeriesItemMdodel> GetSeries();
        _InputModel GetBy(int Id);
        void Delete(int id);
        bool IsDuplicatedOnName(string name);
    }
}
