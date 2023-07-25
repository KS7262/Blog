using Blog.DBFiles;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

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
            if (DbActions.ReadByPassword(Email, password) != null)
            {
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
            if (ModelState.IsValid)
            {
                DbActions.CreateUser(new User { FirstName = firstName, LastName = lastName, Email = email, Password = password });
                Directory.CreateDirectory($"wwwroot/UsersFiles/{firstName}{lastName}{email}");
                return RedirectToAction("UserPage", "Account");
            }
            else
                return View();
        }
    }
}
