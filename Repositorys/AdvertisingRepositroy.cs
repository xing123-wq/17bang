using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class AdvertisingRepositroy : BaseRepository<Advertising>
    {
        public AdvertisingRepositroy(SQLContext context) : base(context)
        {
        } 
        public Advertising GetById(int id)
        {
            return entities.Where(a => a.Id == id).FirstOrDefault();
        }
        public Advertising GetByTitle(string title)
        {
            return entities.Where(a => a.Title == title).FirstOrDefault();
        }
    }
}
