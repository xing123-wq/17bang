using BLL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class UserRepositroy : BaseRepository<User>
    {
        public UserRepositroy(SQLContext context) : base(context)
        {
            this.context = context;
        }

        public User GetById(int id)
        {
            return entities.Where(u => u.Id == id).SingleOrDefault();
        }
        public User GetByName(string name)
        {
            return entities.Where(u => u.Name == name).SingleOrDefault();
        }
    }
}
