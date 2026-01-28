using System.ComponentModel.DataAnnotations;

namespace RazorApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }
    }
}
