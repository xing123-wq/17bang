using BLL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class SeriesRepository : BaseRepository<Category>
    {
        public SeriesRepository(SqlContext context) : base(context)
        {
        }
        public IQueryable<Category> GetSeries(int userId)
        {
            return entities.Where(s => s.Author.Id == userId);
        }

        public Category GetToId(int Id)
        {
            return entities.Where(s => s.Id == Id).Include(s => s.Parent).SingleOrDefault();
        }

        public bool IsDuplicatedOnName(string name, int id)
        {
            return GetSeries(id).Where(s => s.Title == name).FirstOrDefault() != null;
        }
    }
}
