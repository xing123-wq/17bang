using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class UserRepositroy
    {
        public SQLConnection Connection { get; set; }
        public UserRepositroy()
        {
            Connection = new SQLConnection();
        }
        public void Add(User user)
        {
            Connection.Users.Add(user);
            Connection.SaveChanges();
        }
        public void Remove(User user)
        {
            Connection.Users.Remove(user);
            Connection.SaveChanges();
        }
        public void Update(User user)
        {
            Connection.Users.Attach(user);
            Connection.SaveChanges();
        }
        public User GetById(int id)
        {
            return Connection.Users.Where(u => u.Id == id).SingleOrDefault();
        }
        public User GetByName(string name)
        {
            return Connection.Users.Where(u => u.Name == name).SingleOrDefault();
        }

    }
}
