using BLL;
using Repositorys;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModel.Ad;

namespace ProdService
{
    public class AdService : BaseService, IAdvertisingService
    {
        private AdvertisingRepositroy _repositroy;
        public AdService()
        {
            _repositroy = new AdvertisingRepositroy(context);
        }

        public IList<IndexModel> GetByads(int sum)
        {
            IList<Advertising> advertisings = _repositroy.GetAdvertisings(sum);
            return mapper.Map<IList<IndexModel>>(advertisings);
        }

        public IndexModel GetByTitle(string title)
        {
            Advertising advertising = _repositroy.GetByTitle(title);
            return mapper.Map<IndexModel>(advertising);
        }

        public int Sava(IndexModel model)
        {
            Advertising advertising = mapper.Map<Advertising>(model);
            advertising.Author = GetByCurrentUser();
            advertising.PublishTime = DateTime.Now;
            advertising.Expires = DateTime.Now.AddDays(1);
            _repositroy.Add(advertising);
            return advertising.Id;
        }
        public IEnumerable<SelectListItem> GetSelectListItems(IList<IndexModel> source)
        {
            var selectList = new List<SelectListItem>();
            foreach (var item in source)
            {
                selectList.Add(new SelectListItem { Value = item.Title, Text = item.Title });
            }
            return selectList;
        }
        public IList<IndexModel> Get()
        {
            IList<Advertising> ad = _repositroy.GetAdvertisings(5);
            return mapper.Map<IList<IndexModel>>(ad);
        }
        public IList<IndexModel> GetUserId(int? userId)
        {
            IList<Advertising> ad = _repositroy.GetByUserId(userId);
            return mapper.Map<IList<IndexModel>>(ad);
        }
    }
}
