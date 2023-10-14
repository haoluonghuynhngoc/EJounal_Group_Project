using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Data
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public  DbSet<Articles> Articles { get; set; }
        public  DbSet<ArticlesRating> ArticlesRatings { get; set; }
        public  DbSet<Category> Categories { get; set; }
        public  DbSet<Journals> Journals { get; set; }
        public  DbSet<Review> Reviews { get; set; }
        public  DbSet<Role> Roles { get; set; }
        public  DbSet<Users> Users { get; set; }
        public  DbSet<UsersRole> UsersRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer(GetConnectionString());

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var strConn = config["ConnectionStrings:EntityFramwork"];

            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersRole>(entity => {
                entity.HasKey(ur => new { ur.RoleId, ur.UsersId });
            });
        }
    }
}
