using BLL;
using ExtensionMethods;
using Repositorys;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Register;

namespace ProdService
{
    public class RegisterService : BaseService, IRegisterService
    {
        private User _user;
        public IndexModel GetBy(string name)
        {
             _user = _userRepositroy.GetByName(name);
            return mapper.Map<ViewModel.Register.IndexModel>(_user);
        }
        public int Register(IndexModel model)
        {
            _user = mapper.Map<User>(model);
            _user.InviterCode = StringExtension.GetRandomNumber(4);
            _user.Password = StringExtension.GetMd5Hash(model.Password);
            _user.Inviter = _userRepositroy.GetByInviter(model.Inviter);
            _userRepositroy.Add(_user);
            return _user.Id;
        }
    }
}
