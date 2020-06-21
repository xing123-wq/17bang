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
        private User _user;
        public IndexModel GetBy(string name)
        {
            _user = _userRepositroy.GetByName(name);
            return mapper.Map<ViewModel.LogOn.IndexModel>(_user);
        }
        public int LogOn(IndexModel model)
        {
            _user = mapper.Map<User>(model);
            _userRepositroy.Add(_user);
            return _user.Id;
        }
    }
}
