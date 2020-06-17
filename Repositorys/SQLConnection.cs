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
    public class SQLConnection : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleAndKeyword> ArticleAndKeywords { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<ProblemAndKeyword> ProblemAndKeywords { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public SQLConnection() : base("18bang")
        {
#if DEBUG
            Database.Log = S => File.AppendAllText("E:\\EF.log", S);
#endif
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ArticleAndKeyword>()
                .HasKey(ak => new { ak.ArticleId, ak.KeywordId });

            modelBuilder.Entity<ArticleAndKeyword>()
                .HasRequired(a => a.Article)
                .WithMany(a => a.Keywords)
                .HasForeignKey(a => a.ArticleId);


            modelBuilder.Entity<ArticleAndKeyword>()
               .HasRequired(ak => ak.Keyword)
               .WithMany(ak => ak.Articles)
               .HasForeignKey(ak => ak.KeywordId);

            modelBuilder.Entity<ProblemAndKeyword>()
              .HasKey(pk => new { pk.ProblemId, pk.KeywordId });

            modelBuilder.Entity<ProblemAndKeyword>()
                .HasRequired(pk => pk.Problem)
                .WithMany(p => p.Keywords)
                .HasForeignKey(pk => pk.ProblemId);

            modelBuilder.Entity<ProblemAndKeyword>()
               .HasRequired(pk => pk.Keyword)
               .WithMany(p => p.Problems)
               .HasForeignKey(pk => pk.KeywordId);

            modelBuilder.Entity<Problem>()
              .HasRequired(u => u.Author)
                .WithMany(p => p.Problems)
                .HasForeignKey(s => s.AuthorId);

            modelBuilder.Entity<Article>()
              .HasRequired(a => a.Author)
                .WithMany(u => u.Articles)
                .HasForeignKey(s => s.AuthorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}