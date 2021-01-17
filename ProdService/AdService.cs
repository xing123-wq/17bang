using BLL;
using Repositorys;
using ServiceInterface;
using System.Collections.Generic;
using System.Linq;
using Queqry;
using ViewModel.Ad;
using ViewModel.AdInWidget;

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
            AdInWidget advertising = _repositroy.GetByTitle(title);
            return Mapper.Map<IndexModel>(advertising);
        }

        public int Sava(IndexModel model)
        {
            var advertising = Mapper.Map<AdInWidget>(model);
            advertising.Author = GetByCurrentUser();
            _repositroy.Add(advertising);
            return advertising.Id;
        }
        public IList<_adItmeModel> Get()
        {
            var ad = _repositroy.GetAdvertisings(5);
            return Mapper.Map<IList<_adItmeModel>>(ad);
        }

        public IList<ShowItemModel> GetHistory()
        {
            return GetHistory(GetByCurrentUser());
        }
        private IList<ShowItemModel> GetHistory(Users belong)
        {
            var ads = _repositroy.FindAll()
                .Belong(belong)
                .NotDelete()
                .OrderByDescending(w => w.Id);
            return Mapper.Map<IList<ShowItemModel>>(ads.ToList());
        }
        public IList<IndexModel> GetUserId(int? userId)
        {
            var ad = _repositroy.GetByUserId(userId);
            return Mapper.Map<IList<IndexModel>>(ad);
        }
    }
}
