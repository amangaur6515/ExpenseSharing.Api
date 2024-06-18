using System.ComponentModel.DataAnnotations;

namespace ExpenseSharing.Api.Models
{
    public class CreateExpenseDto
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string PaidBy { get; set; }
        public List<string> SplitAmong {  get; set; }
        [Required] 
        public int GroupId { get; set; }
    }
}
