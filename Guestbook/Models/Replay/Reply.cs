
namespace Guestbook.Models
{
    public class Reply:BaseModel
    {
        public Reply()
        {
            Replies = new HashSet<Reply>();
        }
        public string ReplayContent { get; set;}
        public int? ParentReplyId { get; set; }
        public Reply? ParentReply { get; set; }
        public ICollection<Reply> Replies { get; set; }
        public DateTime Date { get; set; }
        public int MassegeID { get; set; }
        public virtual Massege Massege { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
