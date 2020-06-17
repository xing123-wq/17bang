using BLL;
using Repositorys;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Register;

namespace ProdService
{
    public class RegisterService : BaseService, IRegisterService
    {
        private UserRepositroy _UserRepositroy;
        public RegisterService()
        {
            _UserRepositroy = new UserRepositroy();
        }
        public IndexModel GetBy(string name)
        {
            User user = _UserRepositroy.GetByName(name);
            return null;
        }

        public int Register(IndexModel model)
        {
            return 1;
        }
    }
}
