using ExpenseSharing.Api.Models;
using ExpenseSharing.Api.Repositories.Abstract;
using ExpenseSharing.Api.Services.Abstract;

namespace ExpenseSharing.Api.Services.Implementation
{
    public class ExpenseManagementService : IExpenseManagementService
    {
        private readonly IExpenseManagementRepository _expenseManagementRepository;

        public ExpenseManagementService( IExpenseManagementRepository expenseManagementRepository)
        {
            _expenseManagementRepository = expenseManagementRepository;
        }

        public async Task<bool> CreateExpense(CreateExpenseDto createExpenseDto)
        {
            if(createExpenseDto == null)
            {
                return false;
            }

           
            bool res=await _expenseManagementRepository.CreateExpense(createExpenseDto);
            return res;
        }

        public async Task<List<AllExpensesDto>> GetAllExpenses()
        {
            return await  _expenseManagementRepository.GetAllExpenses();
        }

        public async Task<List<ExpenseDetailsDto>> GetExpenseDetails(int expenseId)
        {
            if(expenseId == 0 || expenseId==null)
            {
                return null;
            }
            var res=await _expenseManagementRepository.GetExpenseDetails(expenseId);
            return res;
        }

        public async Task<List<GroupExpensesDto>> GetGroupExpenses(int groupId)
        {
            if(groupId==0 || groupId == null)
            {
                return null;
            }
            var res=await _expenseManagementRepository.GetGroupExpenses(groupId);
            return res; 
        }

        public async Task<bool> SettleExpense(int expenseId)
        {
            if(expenseId==0 || expenseId == null)
            {
                return false;
            }
            var res = await _expenseManagementRepository.SettleExpense(expenseId);
            return res;

        }
    }
}
