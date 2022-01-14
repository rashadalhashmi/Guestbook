using Guestbook.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Guestbook.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if(loginViewModel.Email=="rashad@gmail.com" && loginViewModel.Password == "rashad")
            {
                List<Claim> claim = new List<Claim>();
                claim.Add(new Claim(ClaimTypes.Name,"rashad"));
                var claimsIdentity=new ClaimsIdentity(claim,CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal= new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimPrincipal);

                return Redirect("/Home/Message");
            }
             return BadRequest();
        }


      public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {

            return View();
        }

        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                return Redirect("/Home/Message");
            }
            return View();
        }
    }
}
