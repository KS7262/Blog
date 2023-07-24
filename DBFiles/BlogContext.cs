using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.DBFiles
{
    public class BlogContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Image> Images { get; set; }

        public BlogContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = BlogDataBase; Trusted_Connection = True; MultipleActiveResultSets = true");
        }
    }
}
