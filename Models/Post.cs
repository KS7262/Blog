using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }
        
        [Required(ErrorMessage ="Введіть текст")]
        public string Text { get; set; }
    }
}
