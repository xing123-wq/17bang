using BLL;
using Repositorys;
using ServiceInterface.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Queqry;
using ViewModel.Category;

namespace ProdService.Category
{
    public class SeriesService : BaseService, ISeriesService
    {
        private readonly CategoryRepository _repository;
        public SeriesService()
        {
            _repository = new CategoryRepository(Context);
        }
        public SeriesItemMdodel Get(int id)
        {
            return Mapper.Map<SeriesItemMdodel>(
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

        public IList<SeriesItemMdodel> GetSeries()
        {
            if (CurrentUserId == null) return null;

            var query = _repository.GetSeries(CurrentUserId.Value);

            return Mapper.Map<IList<SeriesItemMdodel>>(query.ToList());
        }

        public InputModel GetBy(int id)
        {
            BLL.Category series = _repository.GetToId(id);
            if (series != null)
            {
                return Mapper.Map<InputModel>(series);
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

        public _SubManageModel GetSubManage(int parentId)
        {
            _SubManageModel model = new _SubManageModel
            {
                Current = Get(parentId),
                Children = GetChildrenOf(parentId)
            };

            return model;
        }
        public IList<SeriesItemMdodel> GetChildrenOf(int parentId, bool recurse = false)
        {
            if (recurse)
            {
                throw new NotImplementedException();
            }

            IList<BLL.Category> categories = _repository.FindAll()
                .ChildrenOf(_repository.Find(parentId));

            return Mapper.Map<IList<SeriesItemMdodel>>(categories);
        }

        public int Save(InputModel model, bool HasEidt = false)
        {
            var category = Mapper.Map<BLL.Category>(model);
            SetParent(category, model.SelectedCategoryId);
            if (HasEidt)
            {
                if (category.IsDefault)
                {
                    throw new Exception($"修改的系列Id：{model.Id}是系统默认的，不允许被更改。");
                }
                _repository.Update(category);
            }
            else
            {
                category.Author = GetByCurrentUser();
                _repository.Add(category);
            }
            return category.Id;
        }
        private void SetParent(BLL.Category category, int? parentId)
        {
            if (parentId.HasValue)
            {
                category.SetParent(_repository.Find(parentId.Value));
            }
            else
            {
                category.SetParent(null);
            }
        }

        public ManageModel GetManage()
        {
            return new ManageModel
            {
                Items = GetMyList(recurse: false),
                Input = new InputModel { Categories = GetMyList(recurse: true) }
            };
        }
        public IList<SeriesItemMdodel> GetMyList(bool recurse = false)
        {
            return GetList(GetByCurrentUser().Id, recurse);
        }
        public IList<SeriesItemMdodel> GetList(int ownerId, bool recurse = false)
        {
            var query = _repository.FindAll()
                .OwnedBy(UserRepositroy.Find(ownerId));
            if (!recurse)
            {
                query = query.Where(q => q.Parent == null).ToList();
            }
            return Mapper.Map<IList<SeriesItemMdodel>>(query);
        }
    }
}
