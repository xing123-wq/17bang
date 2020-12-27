using BLL;
using Repositorys;
using ServiceInterface.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModel.Category;

namespace ProdService.Category
{
    public class SeriesService : BaseService, ISeriesService
    {
        private SeriesRepository repository;
        public SeriesService()
        {
            repository = new SeriesRepository(context);
        }

        public IList<_ItemMdodel> Get(int userId)
        {
            IList<Series> series = repository.GetSeries(userId);
            return mapper.Map<IList<_ItemMdodel>>(series);
        }

        public _InputModel GetBy(int Id)
        {
            Series series = repository.Find(Id);
            return mapper.Map<_InputModel>(series);
        }

        public int Save(_InputModel model)
        {
            Series series = mapper.Map<Series>(model);
            series.Author = GetByCurrentUser();
            repository.Add(series);
            return series.Id;
        }
    }
}
