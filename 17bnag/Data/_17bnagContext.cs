using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _17bnag.Entitys;
using System.Numerics;

namespace _17bnag.Data
{
    public class _17bnagContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<HelpRelease> HelpRelease { get; set; }
        public DbSet<PublishArticle> PublishArticles { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        //public DbSet<KeywordMiddle> KeywordMiddles { get; set; }
        public DbSet<Notitce> Notitces { get; set; }
        public _17bnagContext(DbContextOptions<_17bnagContext> options)
            : base(options)
        {
        }

        internal PublishArticle GetSngle(int id)
        {
            return PublishArticles.Include(u => u.Author).SingleOrDefault(a => a.Id == id);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<HelpRelease>().ToTable("HelpRelease");
            //modelBuilder.Entity<Keyword>().ToTable("Keywords");
            //modelBuilder.Entity<User>().ToTable("Users");
            //modelBuilder.Entity<KeywordMiddle>()
            //    .HasKey(bk => new { bk.HelpReleaseId, bk.KeywordId });  //唯一可以（推荐）使用联合主键的情景

            //modelBuilder.Entity<KeywordMiddle>()
            //    .HasOne(bk => bk.Keyword)
            //    .WithMany(b => b.HelpReleases)
            //    .HasForeignKey(b => b.HelpReleaseId)
            //    ;

            //modelBuilder.Entity<KeywordMiddle>()
            //    .HasOne(bk => bk.HelpRelease)
            //    .WithMany(b => b.Keywords)
            //    .HasForeignKey(b => b.KeywordId)
            //;

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
