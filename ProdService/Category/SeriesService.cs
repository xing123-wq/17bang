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
        public _SeriesItemMdodel Get(int id)
        {
            return mapper.Map<_SeriesItemMdodel>(
                repository.Find(id));
        }
        public void Delete(int id)
        {
            Series series = repository.Find(id);
            if (series != null)
            {
                if (series.IsDefault)
                {
                    throw new Exception($"删除的系列Id：{id}，是系统默认的，不允许被删除。");
                }
                repository.Remove(series);
            }
            else
            {
                throw new Exception($"找不到该Id：{id},所对应的系列。");
            }
        }

        public IList<_SeriesItemMdodel> GetSeries()
        {
            var query = repository.GetSeries(CurrentUserId.Value);
            return mapper.Map<IList<_SeriesItemMdodel>>(query.ToList());
        }

        public _InputModel GetBy(int Id)
        {
            Series series = repository.GetToId(Id);
            if (series != null)
            {
                return mapper.Map<_InputModel>(series);
            }
            else
            {
                throw new Exception($"找不到该Id：{Id}，所对应的系列。");
            }
        }

        public bool IsDuplicatedOnName(string name)
        {
            return repository.IsDuplicatedOnName(name, CurrentUserId.Value);
        }

        public int Save(_InputModel model, bool HasEidt = false)
        {
            Series series = mapper.Map<Series>(model);
            if (HasEidt)
            {
                if (series.IsDefault)
                {
                    throw new Exception($"修改的系列Id：{model.Id}是系统默认的，不允许被更改。");
                }
                repository.Update(series);
            }
            else
            {
                series.Author = GetByCurrentUser();
                repository.Add(series);
            }
            return series.Id;
        }

        public ManageModel GetManage()
        {
            IQueryable<Series> series = repository.GetSeries(CurrentUserId.Value);
            ManageModel model = new ManageModel
            {
                _Items = mapper.Map<IList<_SeriesItemMdodel>>(series.ToList())
            };
            return model;
        }
    }
}
