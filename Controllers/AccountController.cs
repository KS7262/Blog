using Blog.DBFiles;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class AccountController : Controller
    {
        public static User User { private get; set; }
        PageObjects pageObjects = new PageObjects();
        public IActionResult UserPage()
        {
            pageObjects.User = User;
            pageObjects.Post = PostDbActions.ReadPosts(User);
            pageObjects.Image = ImageDbActions.ReadSrc(User);
            return View();
        }
    }
}
