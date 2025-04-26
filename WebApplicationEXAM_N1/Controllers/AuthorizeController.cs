using Microsoft.AspNetCore.Mvc;
using WebApplicationEXAM_N1.Helpers;
using WebApplicationEXAM_N1.Models;
using WebApplicationEXAM_N1.Services;

namespace WebApplicationEXAM_N1.Controllers
{
    public class AuthorizeController : Controller
    {

        private readonly AuthorizeService authorizeService;


        public AuthorizeController(AuthorizeService authorizeService)
        {
            this.authorizeService = authorizeService;
        }


        public IActionResult Index()
        {
            if (AuthorizeHelper.CurrentLogingUserToken != string.Empty)
            {
                return RedirectToAction("Index", "Home");
                
            }
            return View();
        }

        public IActionResult Register()
        {

            if (AuthorizeHelper.CurrentLogingUserToken != string.Empty)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }




        [HttpPost]
        public IActionResult UserRegister(string login, string name, string email, string password, string confirmPassword, bool isAdmin)
        {
            if (password != confirmPassword)
            {
                
                return View("Register");
            }
            var user = new User()
            {
                Name = name,
                Email = email,
                Role = isAdmin ? UserRole.Admin : UserRole.User,
                UserData = new UserData()
                {
                    Login = login,
                    PasswordHash = password,
                    Token = string.Empty
                }
                
            };


            var res = authorizeService.Register(user);
            if (res != string.Empty)
            {
                AuthorizeHelper.CurrentLogingUserToken = authorizeService.GetUserToken(user.UserData.Login, user.UserData.PasswordHash);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Register");
            }
        }

        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            var res = authorizeService.Authenticate(login, password);
            if (res == true)
            {
                AuthorizeHelper.CurrentLogingUserToken = authorizeService.GetUserToken(login, password);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Index");
            }
        }

        public IActionResult Logout()
        {
            AuthorizeHelper.CurrentLogingUserToken = string.Empty;
            return RedirectToAction("Index", "Home");
        }




    }
}
