using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guestbook.Models
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany<Massege>(a=>a.Masseges).WithOne(m=>m.User).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany<Reply>(r => r.Replies).WithOne(m => m.User).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
