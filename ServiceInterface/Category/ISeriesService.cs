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
        int Save(InputModel model, bool HasEidt = false);
        ManageModel GetManage();
        IList<SeriesItemMdodel> GetSeries();
        InputModel GetBy(int Id);
        void Delete(int id);
        SeriesItemMdodel Get(int id);
        bool IsDuplicatedOnName(string name);
        _SubManageModel GetSubManage(int parentId);
    }
}
