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
        private UserRepositroy _userRepositroy { get => new UserRepositroy(context); }
        public IndexModel GetBy(string name)
        {
            User user = _userRepositroy.GetByName(name);
            return mapper.Map<ViewModel.Register.IndexModel>(user);
        }
        public int Register(IndexModel model)
        {
            User user = mapper.Map<User>(model);
            user.InviterCode = StringExtension.GenerateRandomNumber(4);
            user.Password = StringExtension.GetMd5Hash(model.Password);
            user.InviterId = _userRepositroy.GetByInviter(model.Inviter).Id;
            _userRepositroy.Add(user);
            return user.Id;
        }

    }
}
