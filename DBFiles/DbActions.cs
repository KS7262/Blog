using Blog.Models;

namespace Blog.DBFiles
{
    public static class DbActions
    {
        public static void CreateUser(User user)
        {
            using (BlogContext db = new BlogContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public static User? ReadByPassword(string Email, string Password)
        {
            using (BlogContext db = new BlogContext())
            {
                foreach (var user in db.Users)
                {
                    if (user.Email == Email && user.Password == Password)
                    {
                        return user;
                    }
                }
                return null;
            }
        }

    }
}
