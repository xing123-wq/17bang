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

        public void Delete(int id)
        {
            Series series = repository.Find(id);
            if (series != null)
            {
                repository.Remove(series);
            }
            else
            {
                throw new Exception($"找不到该Id：{id},所对应的系列。");
            }
        }

        public IList<_ItemMdodel> Get(int userId)
        {
            var query = repository.GetSeries(userId);
            return mapper.Map<IList<_ItemMdodel>>(query.ToList());
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
                repository.Update(series);
            }
            else
            {
                series.Author = GetByCurrentUser();
                repository.Add(series);
            }
            return series.Id;
        }
    }
}
