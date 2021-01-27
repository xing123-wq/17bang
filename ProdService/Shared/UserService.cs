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
            _user = UserRepositroy.GetByName(name);
            return Mapper.Map<L.IndexModel>(_user);
        }
        public L.IndexModel GetBy()
        {
            _user = GetByCurrentUser();
            return Mapper.Map<ViewModel.LogOn.IndexModel>(_user);
        }
        public int LogOn(L.IndexModel model)
        {
            _user = Mapper.Map<Users>(model);
            _user = UserRepositroy.GetByName(model.UserName);
            return _user.Id;
        }
        public R.IndexModel GetBy(string name)
        {
            _user = UserRepositroy.GetByName(name);
            return Mapper.Map<R.IndexModel>(_user);
        }
        public int Register(R.IndexModel model)
        {
            _user = Mapper.Map<Users>(model);
            _user.InviterCode = StringExtension.GetRandom(4);
            _user.Password = StringExtension.GetMd5Hash(model.Password);
            _user.Inviter = UserRepositroy.GetByInviter(model.Inviter);
            _user.Role = Global.Role.Logon;
            UserRepositroy.Add(_user);
            return _user.Id;
        }

        public _UserModel _Get(int id)
        {
            return Mapper.Map<_UserModel>(UserRepositroy.Find(id));
        }
    }
}
