﻿using ExpenseSharing.Api.Data;
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

        public async Task<List<AllExpensesDto>> GetAllExpenses()
        {
            var expensesList = _db.Expenses.ToList();

            //list to be returned
            List<AllExpensesDto> allExpensesList = new List<AllExpensesDto>();

            //tranverse the expenses list which we got from the table
            foreach(var expense in expensesList)
            {
                //find the group to which the expense belong
                var group=_db.Groups.FirstOrDefault(grp => grp.Id == expense.GroupId);
                //create the AllExpenseDto object and then insert into the ans list
                AllExpensesDto dto = new AllExpensesDto()
                {
                    ExpenseId=expense.Id,
                    GroupName=group.GroupName,
                    ExpenseDescription=expense.Description,
                    Amount=expense.Amount,
                    PaidByUserEmail=expense.PaidByUserEmail,
                    CreatedDate=expense.CreatedAt,
                    IsSettled=expense.IsSettled,
                };
                allExpensesList.Add(dto);
                
            }
            return allExpensesList;
        }

        public async Task<List<ExpenseDetailsDto>> GetExpenseDetails(int expenseId)
        {
            //list to store expense details objects
            List<ExpenseDetailsDto> expenseDetails = new List<ExpenseDetailsDto>();
            //find all the records with the matching expenseId, from expense splits table
            var expenseSplits=_db.ExpenseSplits.Where(exp=>exp.ExpenseId == expenseId).ToList();

            foreach(var  expense in expenseSplits)
            {
                ExpenseDetailsDto expenseDetailsDto = new ExpenseDetailsDto()
                {
                    UserEmail= expense.UserEmail,
                    Amount = expense.Amount,
                };
                expenseDetails.Add(expenseDetailsDto);
            }
            return expenseDetails;
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

        public async Task<bool> SettleExpense(int expenseId)
        {
            //find the expense record from the expenses table
            var expense=_db.Expenses.FirstOrDefault(exp => exp.Id == expenseId);
            if (expense != null)
            {
                expense.IsSettled = true;
                //foreach record in expense split table with matching expense id, make amount as 0
                var expenseSplitsList= _db.ExpenseSplits.Where(exp=>exp.ExpenseId == expenseId).ToList();
                //for each expensesplit obj in the list make amount as 0
                foreach(var  ex in  expenseSplitsList)
                {
                    ex.Amount = 0;
                    _db.SaveChanges();
                }
                _db.SaveChanges();
                return true;

            }
            return false;
        }
    }
}
