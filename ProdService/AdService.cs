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
        private readonly AdvertisingRepositroy _repositroy;
        public AdService()
        {
            _repositroy = new AdvertisingRepositroy(Context);
        }

        public IList<IndexModel> GetByads(int sum)
        {
            var advertisings = _repositroy.GetAdvertisings(sum);
            return Mapper.Map<IList<IndexModel>>(advertisings);
        }

        public IndexModel GetByTitle(string title)
        {
            Advertising advertising = _repositroy.GetByTitle(title);
            return Mapper.Map<IndexModel>(advertising);
        }

        public int Sava(IndexModel model)
        {
            var advertising = Mapper.Map<Advertising>(model);
            advertising.Author = GetByCurrentUser();
            _repositroy.Add(advertising);
            return advertising.Id;
        }
        public IList<_adItmeModel> Get()
        {
            var ad = _repositroy.GetAdvertisings(5);
            return Mapper.Map<IList<_adItmeModel>>(ad);
        }
        public IList<IndexModel> GetUserId(int? userId)
        {
            var ad = _repositroy.GetByUserId(userId);
            return Mapper.Map<IList<IndexModel>>(ad);
        }
    }
}
