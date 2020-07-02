using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class SeriesRepository : BaseRepository<Series>
    {
        public SeriesRepository(SQLContext context) : base(context)
        {
        }
        public IList<Series> GetSeries(User user)
        {
            return entities.Where(s => s.Author == user).ToList();
        }
    }
}
