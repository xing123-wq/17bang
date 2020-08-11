using BLL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public IList<Series> GetSeries(int userId)
        {
            return entities.Where(s => s.Author.Id == userId).Include(s => s.SeriesLevel).ToList();
        }
    }
}
