  namespace Guestbook.Models
{
    public class Massege :BaseModel
    {
        public string MassegeContent { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Reply> Replies  { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; internal set; }
    }
}
