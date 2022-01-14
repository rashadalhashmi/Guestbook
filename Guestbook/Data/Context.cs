using Guestbook.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Guestbook.Data
{
 
    public class Context:DbContext
    {
        public Context(DbContextOptions options):base(options)
        {
                    
        }

        public DbSet<Massege> Masseges;
        public DbSet<Reply> Replies;
        public DbSet<ApplicationUser> Users;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MassegeConfigtation());
            modelBuilder.ApplyConfiguration(new ReplyConfigration());
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
        }
    }
}
