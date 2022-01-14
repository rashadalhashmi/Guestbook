using Guestbook.Models;
using System.ComponentModel.DataAnnotations;

namespace Guestbook.ViewModels
{
    public class RegisterViewModel
    {
        [Required][MinLength(3)][MaxLength(15)]
        public string FirstName { get; set; }
        [Required][MinLength(3)][MaxLength(15)]
        public string LastName { get; set; }
        [Required][MinLength(6)][MaxLength(15)]
        public string Password { get; set; }
        [Required][EmailAddress]
        public string Email { get; set; }
    }

    // this is extension method convert from  RegisterViewModel to ApplicationUser 
    public static class RegisterViewModelExtensions
    {
        public static ApplicationUser ToApplicationUserModel(this RegisterViewModel registerViewModel)
        {
            return new ApplicationUser
            {
                Email = registerViewModel.Email,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Password = registerViewModel.Password,

            };
           }
    }
}
