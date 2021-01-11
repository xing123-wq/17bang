using BLL;
using ExtensionMethods;
using ServiceInterface.Shared;
using ViewModel.Shared;
using L = ViewModel.LogOn;
using R = ViewModel.Register;

namespace ProdService.Shared
{
    public class UserService : BaseService, IUserService
    {
        private Users _user;
        public L.IndexModel GetByName(string name)
        {
            _user = _userRepositroy.GetByName(name);
            return mapper.Map<L.IndexModel>(_user);
        }
        public L.IndexModel GetBy()
        {
            _user = GetByCurrentUser();
            return mapper.Map<ViewModel.LogOn.IndexModel>(_user);
        }
        public int LogOn(L.IndexModel model)
        {
            _user = mapper.Map<Users>(model);
            _user = _userRepositroy.GetByName(model.UserName);
            return _user.Id;
        }
        public R.IndexModel GetBy(string name)
        {
            _user = _userRepositroy.GetByName(name);
            return mapper.Map<R.IndexModel>(_user);
        }
        public int Register(R.IndexModel model)
        {
            _user = mapper.Map<Users>(model);
            _user.InviterCode = StringExtension.GetRandomNumber(4);
            _user.Password = StringExtension.GetMd5Hash(model.Password);
            _user.Inviter = _userRepositroy.GetByInviter(model.Inviter);
            _user.Role = Global.Role.Logon;
            _userRepositroy.Add(_user);
            return _user.Id;
        }

        public _UserModel _Get(int id)
        {
            return mapper.Map<_UserModel>(_userRepositroy.Find(id));
        }
    }
}
