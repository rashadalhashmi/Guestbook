using System.ComponentModel.DataAnnotations;

namespace Guestbook.ViewModels
{
    public class LoginViewModel
    {
        [Required][EmailAddress]
        public string Email { get; set; }
        [Required][MinLength(6)][MaxLength(15)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/Home/Message";
    }
}
