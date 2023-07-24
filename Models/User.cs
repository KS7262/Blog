using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Введіть ім'я")]
        [MinLength(2, ErrorMessage ="Мінімальна довжина 2 символи!")]
        public string FirstName { get; set; }

        [MinLength(2, ErrorMessage = "Мінімальна довжина 2 символи!")]
        [Required(ErrorMessage = "Введіть прізвище")]
        public string LastName { get; set; }
        

        [Required(ErrorMessage = "Введіть пошту")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Введіть правильну пошту")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Введіть пароль")]
        [MinLength(8, ErrorMessage = "Мінімальна довжина паролю 8 символів")]
        [RegularExpression(@"^\S+$", ErrorMessage = "Введіть коректний пароль")]
        public string Password { get; set; }

    }
}
