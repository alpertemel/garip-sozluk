using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Data
{
    public class GaripSozlukDbContext : IdentityDbContext<User, Role, int> //IdentityDbContext
    {
        public GaripSozlukDbContext() : base()
        {

        }
        public GaripSozlukDbContext(DbContextOptions options) : base(options)
        {

        }

        //public DbSet<User> Users { get; set; }
        public DbSet<HeaderCategory> Categories { get; set; }
        public DbSet<Header> Headers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostRating> PostRatings { get; set; }
        public DbSet<BlockedUser> BlockedUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            builder.ApplyConfiguration(new HeaderCategoryMapping());
            builder.ApplyConfiguration(new HeaderMapping());
            builder.ApplyConfiguration(new PostMapping());
            builder.ApplyConfiguration(new PostRatingMapping());
            builder.ApplyConfiguration(new BlockedUserMapping());
            builder.ApplyConfiguration(new UserMapping());

            builder.Entity<HeaderCategory>().HasData(new List<HeaderCategory>
            {
                new HeaderCategory(){ Id=1, CreateDate=DateTime.Now, Title="Gündem"},
                new HeaderCategory(){ Id=2, CreateDate=DateTime.Now, Title="Debe"},
                new HeaderCategory(){ Id=3, CreateDate=DateTime.Now, Title="Sorunsallar"},
                new HeaderCategory(){ Id=4, CreateDate=DateTime.Now, Title="#Spor"},
                new HeaderCategory(){ Id=5, CreateDate=DateTime.Now, Title="#İlişkiler"},
                new HeaderCategory(){ Id=6, CreateDate=DateTime.Now, Title="#Siyaset"}
            });

            builder.Entity<Role>().HasData(new List<Role>()
            {
                new Role(){ Id=1, NormalizedName="USER",Name="User",  },
                new Role(){ Id=2, NormalizedName="ADMIN", Name="Admin" }
            });

            base.OnModelCreating(builder);

        }
    }
}
