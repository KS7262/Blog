using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class AccountController : Controller
    {
        public static User User { private get; set; }

        public IActionResult UserPage()
        {
            return View();
        }
    }
}
