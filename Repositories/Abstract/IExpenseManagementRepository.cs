using ExpenseSharing.Api.Models;
using System.Reflection.Metadata.Ecma335;

namespace ExpenseSharing.Api.Repositories.Abstract
{
    public interface IExpenseManagementRepository
    {
        public Task<bool> CreateExpense(CreateExpenseDto createExpenseDto);


        //returns all expenses withing the group
        public Task<List<GroupExpensesDto>> GetGroupExpenses(int groupId);
    }
}
