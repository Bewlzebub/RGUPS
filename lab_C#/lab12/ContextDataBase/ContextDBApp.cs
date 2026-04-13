using Microsoft.EntityFrameworkCore;
using lab10_ASP.Models;

namespace lab10_ASP.Context
{
#pragma warning disable IDE0290 // Использовать основной конструктор
    public class ContextDBApp : DbContext
    {
        public ContextDBApp(DbContextOptions<ContextDBApp> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Начальные данные для Role
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin", Description = "Administrator" },
                new Role { Id = 2, Name = "User", Description = "Regular user" },
                new Role { Id = 3, Name = "Guest", Description = "Guest user" }
            );

            // Начальные данные для User
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Admin User", Email = "admin@example.com", RoleId = 1 },
                new User { Id = 2, Name = "John Doe", Email = "john@example.com", RoleId = 2 }
            );
        }
    }
#pragma warning restore IDE0290
}