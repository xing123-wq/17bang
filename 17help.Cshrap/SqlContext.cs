using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class SqlContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        DBhelper Bhelper = new DBhelper();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=18bang;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(cs);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
