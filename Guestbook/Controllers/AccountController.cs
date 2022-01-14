using Guestbook.Models;
using Guestbook.Repositories;
using Guestbook.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Guestbook.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMainRepository<ApplicationUser> _mainRepository;
        public AccountController(IMainRepository<ApplicationUser> mainRepository)
        {
                _mainRepository=mainRepository;
        }
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _mainRepository.FindOne(u => u.Email == loginViewModel.Email && u.Password == loginViewModel.Password);

                if (user != null)
                {
                    List<Claim> claim = new List<Claim>();
                    claim.Add(new Claim(ClaimTypes.Name, user.FirstName));
                    claim.Add(new Claim(ClaimTypes.Sid, user.Id.ToString()));
                    var claimsIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimPrincipal);

                    return Redirect("/Home/Message");
                }

                else
                {
                    ViewBag.IsPasswordOrEmailNotFound = true;
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                //check if email is register before or no 
               var user= await  _mainRepository.FindOne(x=>x.Email== registerViewModel.Email);

                // if not register it will add 
                if (user == null)
                {
                   await _mainRepository.Add(registerViewModel.ToApplicationUserModel());
                    return Redirect("/Home/Message");

                }
                else
                {
                    ViewBag.IsEmailUsedBefore = true;
                }

            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
