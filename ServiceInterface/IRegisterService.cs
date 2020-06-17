using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Register;

namespace ServiceInterface
{
    public interface IRegisterService
    {
        IndexModel GetBy(string name);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns>新注册用户的Id</returns>
        int Register(IndexModel model);
    }
}
