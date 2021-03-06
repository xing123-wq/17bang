﻿using BLL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class SqlContext : DbContext
    {
        public SqlContext() : base("18bang")
        {
#if DEBUG
            //Database.Log = S => File.AppendAllText("E:\\EF.log", S);
#endif
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().Ignore(u => u.DefaultSeries);
            modelBuilder.Entity<Problem>();
            modelBuilder.Entity<ProblemAndKeyword>();
            modelBuilder.Entity<Keyword>();
            modelBuilder.Entity<Article>()
                .HasOptional(a => a.Next).WithOptionalDependent();
            modelBuilder.Entity<Article>()
                .HasOptional(a => a.Previous).WithOptionalDependent();
            modelBuilder.Entity<ArticleAndKeyword>();
            modelBuilder.Entity<BanMoney>();
            modelBuilder.Entity<Category>();
            modelBuilder.Entity<AdInWidget>();
            modelBuilder.Entity<Chat>();
            modelBuilder.Entity<Comment>();
            modelBuilder.Entity<Email>();
            modelBuilder.Entity<Appraise>();
            modelBuilder.Entity<ArticleAndKeyword>()
                .HasKey(ak => new { ak.ArticleId, ak.KeywordId });

            modelBuilder.Entity<ProblemAndKeyword>()
                .HasKey(pk => new { pk.ProblemId, pk.KeywordId });


            base.OnModelCreating(modelBuilder);
        }
    }
}
