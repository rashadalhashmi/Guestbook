using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Guestbook.Data
{
 
    public class Context:IdentityDbContext<ApplicationUserEntity>
    {
        public Context(DbContextOptions options):base(options)
        {
                    
        }


    }
}
