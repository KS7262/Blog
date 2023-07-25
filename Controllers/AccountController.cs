using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult UserPage()
        {
            return View();
        }
    }
}
