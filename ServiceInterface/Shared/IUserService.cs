using ViewModel.Shared;
using L = ViewModel.LogOn;
using R = ViewModel.Register;

namespace ServiceInterface.Shared
{
    public interface IUserService
    {
        L.IndexModel GetBy();
        L.IndexModel GetByName(string name);
        int LogOn(L.IndexModel model);
        R.IndexModel GetBy(string name);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns>新注册用户的Id</returns>
        int Register(R.IndexModel model);
        _UserModel _Get(int id);
    }
}
