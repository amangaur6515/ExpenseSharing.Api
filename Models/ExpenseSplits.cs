using System.ComponentModel.DataAnnotations;

namespace ExpenseSharing.Api.Models
{
    public class ExpenseSplits
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ExpenseId { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public decimal Amount { get; set; }

    }
}
