namespace ExpenseSharing.Api.Models
{
    public class AllExpensesDto
    {
        public int ExpenseId { get; set; }
        public string GroupName { get; set; }
        public string ExpenseDescription { get; set; }
        public decimal Amount { get; set; }
        public string PaidByUserEmail { get; set; }
        public bool IsSettled { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
