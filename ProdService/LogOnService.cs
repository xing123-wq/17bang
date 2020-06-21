using BLL;
using Repositorys;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.LogOn;

namespace ProdService
{
    public class LogOnService : BaseService, ILogOnService
    {
        private UserRepositroy _userRepositroy { get => new UserRepositroy(context); }

        public IndexModel GetBy(string name)
        {
            User user = _userRepositroy.GetByName(name);
            return mapper.Map<ViewModel.LogOn.IndexModel>(user);
        }
        public int LogOn(IndexModel model)
        {
            User user = mapper.Map<User>(model);
            _userRepositroy.Add(user);
            return user.Id;
        }
    }
}
