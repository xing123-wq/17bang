using BLL;
using Global;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterface
{
    public interface IBaseService
    {
        void Commit();
        void Rollback();
        void ClearContext();
        int? CurrentUserId { get; }
        Users GetByCurrentUser();
        bool IsAdmin();
    }
}
