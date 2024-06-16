using System.ComponentModel.DataAnnotations;

namespace ExpenseSharing.Api.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
