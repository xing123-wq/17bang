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
        private readonly SeriesRepository _repository;
        public SeriesService()
        {
            _repository = new SeriesRepository(Context);
        }
        public _SeriesItemMdodel Get(int id)
        {
            return Mapper.Map<_SeriesItemMdodel>(
                _repository.Find(id));
        }
        public void Delete(int id)
        {
            var series = _repository.Find(id);
            if (series != null)
            {
                if (series.IsDefault)
                {
                    throw new Exception($"删除的系列Id：{id}，是系统默认的，不允许被删除。");
                }
                _repository.Remove(series);
            }
            else
            {
                throw new Exception($"找不到该Id：{id},所对应的系列。");
            }
        }

        public IList<_SeriesItemMdodel> GetSeries()
        {
            if (CurrentUserId == null) return null;
            
            var query = _repository.GetSeries(CurrentUserId.Value);
            
            return Mapper.Map<IList<_SeriesItemMdodel>>(query.ToList());
        }

        public _InputModel GetBy(int id)
        {
            Series series = _repository.GetToId(id);
            if (series != null)
            {
                return Mapper.Map<_InputModel>(series);
            }
            else
            {
                throw new Exception($"找不到该Id：{id}，所对应的系列。");
            }
        }

        public bool IsDuplicatedOnName(string name)
        {
            return CurrentUserId != null && _repository.IsDuplicatedOnName(name, CurrentUserId.Value);
        }

        public int Save(_InputModel model, bool HasEidt = false)
        {
            var series = Mapper.Map<Series>(model);
            if (HasEidt)
            {
                if (series.IsDefault)
                {
                    throw new Exception($"修改的系列Id：{model.Id}是系统默认的，不允许被更改。");
                }
                _repository.Update(series);
            }
            else
            {
                series.Author = GetByCurrentUser();
                _repository.Add(series);
            }
            return series.Id;
        }

        public ManageModel GetManage()
        {
            if (CurrentUserId == null) return null;
            
            var series = _repository.GetSeries(CurrentUserId.Value);
            
            ManageModel model = new ManageModel
            {
                _Items = Mapper.Map<IList<_SeriesItemMdodel>>(series.ToList())
            };
            
            return model;

        }
    }
}
