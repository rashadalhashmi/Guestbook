using Microsoft.AspNetCore.Identity;

namespace Guestbook.Models
{
    public class ApplicationUser : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email {get; set;} 
        public virtual ICollection<Reply> Replies { get; set; }
        public virtual ICollection<Massege> Masseges { get; set; }

    }
}