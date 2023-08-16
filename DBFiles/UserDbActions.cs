using Blog.Models;

namespace Blog.DBFiles
{
    public static class UserDbActions
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

        public static bool UniqueEmail(string Email)
        {
            using (BlogContext db = new BlogContext())
            {
                bool isEmailUnique = !db.Users.Any(user => user.Email == Email);

                return isEmailUnique;
            }
        }


        public static List<User> FindUsers(string firstName, string lastName)
        {
            List<User> users = new List<User>();
            using (BlogContext db = new BlogContext())
            {
                foreach (var item in db.Users.Where(u => u.FirstName == firstName && u.LastName == lastName))
                {
                    users.Add(item);
                }
            }
            return users;
        }

        public static User FindUserByEmail(string email)
        {
            using (BlogContext db = new BlogContext())
            {
                return db.Users.FirstOrDefault(u => u.Email == email);
            }
        }
    }
}
