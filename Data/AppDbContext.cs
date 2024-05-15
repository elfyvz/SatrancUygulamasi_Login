using Microsoft.EntityFrameworkCore;
using SatrancUygulamasi.Data.Entities;

namespace SatrancUygulamasi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Parent>().HasData(
        //        new Parent { Id = 1, Name = "Ayşe Yılmaz", Email = "ayse@example.com", Password = "securepassword1" },
        //        new Parent { Id = 2, Name = "Mehmet Demir", Email = "mehmet@example.com", Password = "securepassword2" },
        //        new Parent { Id = 3, Name = "Fatma Korkmaz", Email = "fatma@example.com", Password = "securepassword3" },
        //        new Parent { Id = 4, Name = "Ahmet Can", Email = "ahmet@example.com", Password = "securepassword4" },
        //        new Parent { Id = 5, Name = "Esra Bilgiç", Email = "esra@example.com", Password = "securepassword5" }
        //    );

        //    modelBuilder.Entity<Student>().HasData(
        //        new Student { Id = 1, Name = "Deniz Yılmaz", Age = 14, ParentId = 1, Email = "deniz@example.com", Password = "password123" },
        //        new Student { Id = 2, Name = "Derya Yılmaz", Age = 12, ParentId = 1, Email = "derya@example.com", Password = "password123" },
        //        new Student { Id = 3, Name = "Emre Demir", Age = 15, ParentId = 2, Email = "emre@example.com", Password = "password456" },
        //        new Student { Id = 4, Name = "Büşra Demir", Age = 10, ParentId = 2, Email = "busra@example.com", Password = "password456" },
        //        new Student { Id = 5, Name = "Can Korkmaz", Age = 13, ParentId = 3, Email = "can@example.com", Password = "password789" },
        //        new Student { Id = 6, Name = "İrem Korkmaz", Age = 11, ParentId = 3, Email = "irem@example.com", Password = "password789" },
        //        new Student { Id = 7, Name = "Ali Can", Age = 9, ParentId = 4, Email = "ali@example.com", Password = "password101" },
        //        new Student { Id = 8, Name = "Zeynep Can", Age = 12, ParentId = 4, Email = "zeynep@example.com", Password = "password101" },
        //        new Student { Id = 9, Name = "Merve Bilgiç", Age = 14, ParentId = 5, Email = "merve@example.com", Password = "password202" },
        //        new Student { Id = 10, Name = "Murat Bilgiç", Age = 16, ParentId = 5, Email = "murat@example.com", Password = "password202" }
        //    );

        //    context.SaveChanges();

        //}
    }
}
