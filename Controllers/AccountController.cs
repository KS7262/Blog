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
            pageObjects.PostsText = PostDbActions.ReadPosts(User);
            pageObjects.Image = ImageDbActions.ReadSrc(User);
            return View(pageObjects);
        }
        public IActionResult CreatePost(string text)
        {
            Post post = new Post { Text = text, UserId = User.Id };
            PostDbActions.CreatePost(post);
            return RedirectToAction("UserPage");
        }
    }
}
