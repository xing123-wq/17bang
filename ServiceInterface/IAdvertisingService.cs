using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Advertising;

namespace ServiceInterface
{
    public interface IAdvertisingService
    {
        IndexModel GetByTitle(string title);
        int Sava(IndexModel model);
    }
}
