using BLL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class BaseRepository<T> where T : BaseEntity
    {
        protected SQLContext context;
        public BaseRepository(SQLContext context)
        {
            this.context = context;
        }
        protected DbSet<T> entities
        {
            get
            {
                return context.Set<T>();
            }
        }
        public void Add(T source)
        {
            entities.Add(source);
            context.SaveChanges();
        }
        public void AddRange(IEnumerable<T> source)
        {
            entities.AddRange(source);
            context.SaveChanges();
        }
        public void Remove(T source)
        {
            entities.Remove(source);
            context.SaveChanges();
        }
        public void Update(T source)
        {
            entities.Attach(source);
            context.Entry(source).State = EntityState.Modified;
            context.SaveChanges();
        }
        public T Find(int id)
        {
            return entities.Find(id);
        }
    }
}
