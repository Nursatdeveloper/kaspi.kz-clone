using Banking.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Banking.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to many relationship between User and Account
            // User can have multiple Accounts

            modelBuilder.Entity<Account>()
                .HasOne<User>(u => u.User)
                .WithMany(a => a.Accounts)
                .HasForeignKey(a => a.UserId);
        }
    }
}
