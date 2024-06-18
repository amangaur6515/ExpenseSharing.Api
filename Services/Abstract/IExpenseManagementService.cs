using ExpenseSharing.Api.Models;

namespace ExpenseSharing.Api.Services.Abstract
{
    public interface IExpenseManagementService
    {
        public Task<bool> CreateExpense(CreateExpenseDto createExpenseDto);
        public Task<List<GroupExpensesDto>> GetGroupExpenses(int groupId);
    }
}
