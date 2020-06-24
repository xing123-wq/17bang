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
        private User _user;
        public IndexModel GetByName(string name)
        {
            _user = _userRepositroy.GetByName(name);
            return mapper.Map<ViewModel.LogOn.IndexModel>(_user);
        }
        public IndexModel GetById(int id)
        {
            _user = _userRepositroy.GetById(id);
            return mapper.Map<ViewModel.LogOn.IndexModel>(_user);
        }
        public int LogOn(IndexModel model)
        {
            _user = mapper.Map<User>(model);
            _user = _userRepositroy.GetByName(model.UserName);
            return _user.Id;
        }
    }
}
