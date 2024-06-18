using System.ComponentModel.DataAnnotations;

namespace ExpenseSharing.Api.Models
{
    public class Expenses
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int GroupId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string PaidByUserEmail { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public bool IsSettled { get; set; } = false;
    }
}
