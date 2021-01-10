using UsersManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace UsersManagementApp.Data
{
    public class UserDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=users.db");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserModel>(entity => 
            {
                entity.HasKey(_ => _.Id);
                entity.Property(_ => _.Username).IsRequired();
                entity.Property(_ => _.Password).IsRequired();
                entity.HasIndex(_ => _.Username).IsUnique();
            });

            base.OnModelCreating(builder);
        }
    }
}
