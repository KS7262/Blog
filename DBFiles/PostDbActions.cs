using Blog.Models;
using System.Collections.Generic;

namespace Blog.DBFiles
{
    public class PostDbActions
    {

        public static List<Post> ReadPosts(User user)
        {
            List<Post> posts = new List<Post>();
            using (BlogContext db = new BlogContext())
            {
                foreach (var item in db.Posts.Where(u => u.User == user))
                {
                    posts.Add(item);
                }
            }
            return posts;
        }

        public static void CreatePost(Post post)
        {
            using (BlogContext db = new BlogContext())
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }
        }
    }
}
