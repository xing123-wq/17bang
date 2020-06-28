using BLL;
using Repositorys;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Advertising;

namespace ProdService
{
    public class AdvertisingService : BaseService, IAdvertisingService
    {
        private AdvertisingRepositroy _repositroy;
        public AdvertisingService()
        {
            _repositroy = new AdvertisingRepositroy(context);
        }
        public IndexModel GetByTitle(string title)
        {
            Advertising advertising = _repositroy.GetByTitle(title);
            return mapper.Map<IndexModel>(advertising);
        }

        public int Sava(IndexModel model)
        {
            Advertising advertising = mapper.Map<Advertising>(model);
            advertising.User = GetByCurrentUserId();
            advertising.PublishTime = DateTime.Now;
            advertising.Expires = DateTime.Now.AddDays(1);
            _repositroy.Add(advertising);
            return advertising.Id;
        }
    }
}
