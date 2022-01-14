using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guestbook.Models
{
    public class MassegeConfigtation : IEntityTypeConfiguration<Massege>
    {
        public void Configure(EntityTypeBuilder<Massege> builder)
        {
            builder.HasKey(m=>m.Id);
            builder.Property(m=>m.Id).ValueGeneratedOnAdd();
            builder.Property(m=>m.Date).HasColumnType("date");
            builder.Property(m=>m.MassegeContent).HasMaxLength(500);
            builder.HasMany<Reply>(m => m.Replies).WithOne(r => r.Massege).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne<ApplicationUser>(m => m.User).WithMany(u => u.Masseges).HasForeignKey(m=>m.UserId);

        }
    }
}
