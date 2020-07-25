using BLL;
using Repositorys;
using ServiceInterface.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModel.Articles;

namespace ProdService.Articles
{
    public class SeriesService : BaseService, ISeriesService
    {
        private SeriesRepository repository;
        public SeriesService()
        {
            repository = new SeriesRepository(context);
        }

        public IList<SeriesModel> Get()
        {
            User user = GetByCurrentUser();
            IList<Series> series = repository.GetSeries(user.Id);
            return mapper.Map<IList<SeriesModel>>(series);
        }

        public int Save(SeriesModel model)
        {
            Series series = mapper.Map<Series>(model);
            series.Author = GetByCurrentUser();
            repository.Add(series);
            return series.Id;
        }
        public IEnumerable<SelectListItem> GetSelectListItems(IList<SeriesModel> source)
        {
            var selectList = new List<SelectListItem>();
            foreach (var item in source)
            {
                selectList.Add(new SelectListItem { Value = item.Title, Text = item.Title });
            }
            return selectList;
        }
    }
}
