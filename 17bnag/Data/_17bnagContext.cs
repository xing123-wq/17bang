using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _17bnag.Entitys;

namespace _17bnag.Data
{
    public class _17bnagContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<HelpRelease> HelpRelease { get; set; }
        public DbSet<PublishArticle> PublishArticles { get; set; }
        public DbSet<Keyword> Keywords { get; set; }

        public DbSet<KeywordMiddle> KeywordMiddles { get; set; }
        public DbSet<UsersMiddle> UsersMiddles { get; set; }
        public _17bnagContext(DbContextOptions<_17bnagContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<HelpRelease>().ToTable("HelpRelease");
            //modelBuilder.Entity<Keyword>().ToTable("Keywords");
            //modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<KeywordMiddle>()
                .HasKey(bk => new { bk.HelpReleaseId, bk.KeywordId });  //唯一可以（推荐）使用联合主键的情景

            modelBuilder.Entity<KeywordMiddle>()
                .HasOne(bk => bk.Keyword)
                .WithMany(b => b.HelpReleases)
                .HasForeignKey(b => b.HelpReleaseId)
                ;

            modelBuilder.Entity<KeywordMiddle>()
                .HasOne(bk => bk.HelpRelease)
                .WithMany(b => b.Keywords)
                .HasForeignKey(b => b.KeywordId)
                ;

            modelBuilder.Entity<UsersMiddle>()
                .HasKey(bk => new { bk.HelpReleaseId, bk.UserId });  //唯一可以（推荐）使用联合主键的情景

            modelBuilder.Entity<UsersMiddle>()
                .HasOne(bk => bk.users)
                .WithMany(b => b.HelpRelease)
                .HasForeignKey(b => b.HelpReleaseId)
                ;

            modelBuilder.Entity<UsersMiddle>()
                .HasOne(bk => bk.HelpRelease)
                .WithMany(b => b.User)
                .HasForeignKey(b => b.UserId)
                ;
        }

    }
}
