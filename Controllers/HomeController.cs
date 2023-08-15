using Blog.DBFiles;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Autorization(string Email, string password)
        {
            if (UserDbActions.ReadByPassword(Email, password) != null)
            {
                AccountController.User = UserDbActions.ReadByPassword(Email, password);
                return RedirectToAction("UserPage", "Account");
            }
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(string firstName, string lastName, string email, string password)
        {
            if (ModelState.IsValid && UserDbActions.UniqueEmail(email))
            {
                User user = new User { FirstName = firstName, LastName = lastName, Email = email, Password = password };

                UserDbActions.CreateUser(user);

                Directory.CreateDirectory($"wwwroot/UsersFiles/{email}");
                System.IO.File.Copy($"wwwroot/images/blank-profile-picture.jpg", $"wwwroot/UsersFiles/{email}/blank-profile-picture.jpg", true);

                Image image = new Image { Src = $"UsersFiles/{email}/blank-profile-picture.jpg", UserId = user.Id };
                ImageDbActions.CreateImage(image);

                AccountController.User = user;

                return RedirectToAction("UserPage", "Account");
            }
            else
                return View();
        }
    }
}
