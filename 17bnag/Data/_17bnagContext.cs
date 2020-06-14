using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _17bnag.Entitys;
using System.Numerics;
using _17bnag.Model.Log;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace _17bnag.Data
{
    public class _17bnagContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<OnModel> onModels { get; set; }
        public DbSet<HelpRelease> HelpRelease { get; set; }
        public DbSet<PublishArticle> PublishArticles { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<ArticleMap> ArticleMaps { get; set; }
        public DbSet<KeywordMiddle> KeywordMiddles { get; set; }
        public DbSet<Notitce> Notitces { get; set; }
        public _17bnagContext(DbContextOptions<_17bnagContext> options)
            : base(options)
        {
        }

        internal PublishArticle GetSngle(int id)
        {
            return PublishArticles.Include(u => u.Author).Include(k => k.keywords).ThenInclude(k => k.Keyword).SingleOrDefault(a => a.Id == id);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleMap>()
                .HasKey(ak => new { aId = ak.ArticleId, kId = ak.KeywordId });

            modelBuilder.Entity<ArticleMap>()
                .HasOne(ak => ak.Article)
                .WithMany(a => a.keywords)
                .HasForeignKey(ak => ak.ArticleId);

            modelBuilder.Entity<ArticleMap>()
               .HasOne(ak => ak.Keyword)
               .WithMany(a => a.Articles)
               .HasForeignKey(ak => ak.KeywordId);

            modelBuilder.Entity<KeywordMiddle>()
              .HasKey(pk => new { pId = pk.HelpReleaseId, kId = pk.KeywordId });

            modelBuilder.Entity<KeywordMiddle>()
                .HasOne(pk => pk.HelpRelease)
                .WithMany(p => p.Keywords)
                .HasForeignKey(pk => pk.HelpReleaseId);

            modelBuilder.Entity<KeywordMiddle>()
               .HasOne(pk => pk.Keyword)
               .WithMany(p => p.Problems)
               .HasForeignKey(pk => pk.KeywordId);

            modelBuilder.Entity<User>()
              .HasMany<HelpRelease>(g => g.HelpRelease)
                .WithOne(s => s.Users)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<User>()
              .HasMany<PublishArticle>(g => g.PublishArticles)
                .WithOne(s => s.Author)
                .HasForeignKey(s => s.AuthorId);


            modelBuilder.Entity<User>()
              .HasMany<Notitce>(g => g.Notitces)
                .WithOne(s => s.Author)
                .HasForeignKey(s => s.AuthorId);
        }

    }
}
