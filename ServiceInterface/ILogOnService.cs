using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.LogOn;

namespace ServiceInterface
{
    public interface ILogOnService
    {
        IndexModel GetBy(int id);
        IndexModel GetBy(string name);
        int LogOn(IndexModel model);
    }
}
