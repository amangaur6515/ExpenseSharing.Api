using ExpenseSharing.Api.Data;
using ExpenseSharing.Api.Models;
using ExpenseSharing.Api.Repositories.Abstract;

namespace ExpenseSharing.Api.Repositories.Implementation
{
    public class ExpenseManagementRepository : IExpenseManagementRepository
    {
        private readonly ApplicationDbContext _db;
        public ExpenseManagementRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> CreateExpense(CreateExpenseDto createExpenseDto)
        {
            //create the expenses object 
            Expenses expenses = new Expenses()
            {
                Description = createExpenseDto.Description,
                Amount = createExpenseDto.Amount,
                PaidByUserEmail = createExpenseDto.PaidBy,
                GroupId = createExpenseDto.GroupId,
                CreatedAt = DateTime.Now,
                IsSettled = false

            };
            //insert the record of expense int the expense table
            _db.Expenses.Add(expenses);
            _db.SaveChanges();
            //get the number of emails in split among
            decimal numSplitAmong=createExpenseDto.SplitAmong.Count();
            //amount per person
            decimal amountForEach = createExpenseDto.Amount / numSplitAmong;

            //insert the record in Expensesplit table,foreach split among users present
            foreach(var user in createExpenseDto.SplitAmong)
            {
                ExpenseSplits splits = new ExpenseSplits()
                {
                    UserEmail = user,
                    Amount = amountForEach,
                    ExpenseId = expenses.Id
                };
                _db.ExpenseSplits.Add(splits);
                _db.SaveChanges();
            }

            return true;
            
           
        }

        public async Task<List<GroupExpensesDto>> GetGroupExpenses(int groupId)
        {
            //find  all group expenses  record by groupId
            var groupExpenses=_db.Expenses.Where(exp=>exp.GroupId == groupId).ToList(); 

            //list to return which will contain list of expenses with in group
            List<GroupExpensesDto> groupExpensesDtos = new List<GroupExpensesDto>();

            foreach(var groupExpense in groupExpenses)
            {
                GroupExpensesDto expensesDto = new GroupExpensesDto()
                {
                    ExpenseDescription = groupExpense.Description,
                    ExpenseAmount = groupExpense.Amount,
                    PaidBy = groupExpense.PaidByUserEmail,
                    CreatedAt = groupExpense.CreatedAt,
                    IsSettled = groupExpense.IsSettled,
                    ExpenseId=groupExpense.Id,
                    
                };
                groupExpensesDtos.Add(expensesDto);
            }
            return groupExpensesDtos;
            
        }
    }
}
