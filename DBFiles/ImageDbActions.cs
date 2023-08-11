using Blog.Models;

namespace Blog.DBFiles
{
    public class ImageDbActions
    {
        public static void CreateImage(Image image)
        {
            using (BlogContext db = new BlogContext())
            {
                db.Images.Add(image);
                db.SaveChanges();
            }
        }
        public static string ReadSrc(User user)
        {
            using (BlogContext db = new BlogContext())
            {
                var src = db.Images.FirstOrDefault(u => u.User == user);

                if (src != null)
                {
                    return src.Src;
                }
                else
                {
                    return ""; 
                }
            }
        }


    }
}

