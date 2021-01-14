using BLL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class UserRepositroy : BaseRepository<Users>
    {
        public UserRepositroy(SqlContext context) : base(context)
        {
        }

        public Users GetById(int id)
        {
            return entities.Where(u => u.Id == id).SingleOrDefault();
        }
        public Users GetByName(string name)
        {
            return entities.Where(u => u.Name == name).FirstOrDefault();

        }
        public Users GetByInviter(string inviter)
        {
            return entities.FirstOrDefault(u => u.Name == inviter);
        }

        public Users GetEmail()
        {
            return entities.Include(u => u.Email).FirstOrDefault();
        }
    }
}
