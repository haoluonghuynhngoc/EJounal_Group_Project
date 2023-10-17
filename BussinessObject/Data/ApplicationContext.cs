using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;

namespace BussinessObject.Data
{
    public partial class ApplicationContext : DbContext
    {
        //public ApplicationContext()
        //{
        //}
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Articles> Articles { get; set; }
        public DbSet<Fields> Fields { get; set; }
        public DbSet<Journals> Journals { get; set; }
        public DbSet<Majors> Majors { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Users> Users { get; set; }

        // Join Table
        public DbSet<UsersRole> UsersRoles { get; set; }
        public DbSet<UserMajors> UserMajors { get; set; }
        public DbSet<ReviewResult> ReviewResults { get; set; }
        public DbSet<ReviewFields> ReviewFields { get; set; }
        public DbSet<Contributors> Contributors { get; set; }
        public DbSet<ArticleFields> ArticleFields { get; set; }
        // end Join table

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseSqlServer(GetConnectionString());

        // private string GetConnectionString()
        // {
        //     IConfiguration config = new ConfigurationBuilder()
        //      .SetBasePath(Directory.GetCurrentDirectory())
        //     .AddJsonFile("appsettings.json", true, true)
        //     .Build();
        //     var strConn = config["ConnectionStrings:EntityFramwork"];

        //     return strConn;
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(r => r.Name).HasConversion<string>();
            });
            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(s => s.Status).HasConversion<string>();
            });
            modelBuilder.Entity<Articles>(entity =>
            {
                entity.Property(s => s.Status).HasConversion<string>();
            });
            modelBuilder.Entity<Journals>(entity =>
            {
                entity.Property(j => j.Status).HasConversion<string>();
            });
            modelBuilder.Entity<UsersRole>(entity =>
            {
                entity.HasKey(ur => new { ur.RoleId, ur.UsersId });
            });
            modelBuilder.Entity<UserMajors>(entity =>
            {
                entity.HasKey(ur => new { ur.UsersId, ur.MajorId });
            });
            modelBuilder.Entity<ReviewResult>(entity =>
            {
                entity.HasKey(ur => new { ur.ArticlesId, ur.UsersId });
            });
            modelBuilder.Entity<ReviewFields>(entity =>
            {
                entity.HasKey(ur => new { ur.FieldsId, ur.UsersId });
            });
            modelBuilder.Entity<Contributors>(entity =>
            {
                entity.HasKey(ur => new { ur.ArticlesId, ur.UsersId });
            });
            modelBuilder.Entity<ArticleFields>(entity =>
            {
                entity.HasKey(ur => new { ur.ArticlesId, ur.FieldsId });
            });
        }
    }
}
