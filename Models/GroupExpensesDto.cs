namespace ExpenseSharing.Api.Models
{
    public class GroupExpensesDto
    {
        //to return all expenses with in the group
        
        public int ExpenseId { get; set; }
        public string ExpenseDescription { get; set; }
        public decimal ExpenseAmount { get; set; }
        public string PaidBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsSettled { get; set; }

    }
}
