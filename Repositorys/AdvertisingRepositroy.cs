using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class AdvertisingRepositroy : BaseRepository<AdInWidget>
    {
        public AdvertisingRepositroy(SqlContext context) : base(context)
        {
        }
      
        public AdInWidget GetById(int id)
        {
            return entities.FirstOrDefault(a => a.Id == id);
        }
        public AdInWidget GetByTitle(string title)
        {
            return entities.FirstOrDefault(a => a.Title == title);
        }
        public IList<AdInWidget> GetAdvertisings(int sum)
        {
            return entities.OrderByDescending(a => a.Id).Take(sum).ToList();
        }
        public IList<AdInWidget> GetByUserId(int? userId)
        {
            return entities.Where(a => a.Author.Id == userId).ToList();
        }
    }
}
