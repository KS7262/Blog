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

        public IActionResult ChangeImage(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                string email = User.Email;
                
                System.IO.File.Delete($"wwwroot/UsersFiles/{email}/blank-profile-picture.jpg");
                
                string uploadsFolder = Path.Combine("wwwroot", "UsersFiles", email.ToString());
                string uniqueFileName = Path.Combine(uploadsFolder, "blank-profile-picture.jpg");

                using (var fileStream = new FileStream(uniqueFileName, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }
            }

            return RedirectToAction("UserPage");
        }
    }
}
