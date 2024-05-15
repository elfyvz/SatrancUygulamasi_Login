using System.ComponentModel.DataAnnotations;

namespace SatrancUygulamasi.Data.Entities
{
    public class Parent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public ICollection<Student>? Students { get; set; } = new List<Student>();
    }
}
