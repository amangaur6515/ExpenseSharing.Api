﻿using ExpenseSharing.Api.Models;
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

            //check if paid by person and any split among person same
            foreach(var user in createExpenseDto.SplitAmong)
            {
                if(user==createExpenseDto.PaidBy)
                {
                    //paid by person can't be included in split among
                    return false;
                }
            }
            bool res=await _expenseManagementRepository.CreateExpense(createExpenseDto);
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
    }
}
