using BLL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class SQLConnection : DbContext
    {
        DbSet<User> Users { get; set; }
        public SQLConnection() : base("17bang")
        {
#if DEBUG
            Database.Log = S => File.AppendAllText("E:\\EF.log", S);
#endif
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
