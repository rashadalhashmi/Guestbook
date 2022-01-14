using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guestbook.Models
{
    public class ReplyConfigration : IEntityTypeConfiguration<Reply>
    {
        public void Configure(EntityTypeBuilder<Reply> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne<Massege>(r => r.Massege).WithMany(m => m.Replies).HasForeignKey(r => r.MassegeID);
            builder.HasOne<ApplicationUser>(r => r.User).WithMany(u => u.Replies).HasForeignKey(r => r.UserId);
            builder.HasMany<Reply>(r=>r.Replies).WithOne(r=>r.ParentReply).HasForeignKey(r=>r.ParentReplyId).IsRequired(false);


        }
    }
}
