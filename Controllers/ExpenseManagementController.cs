﻿using ExpenseSharing.Api.Models;
using ExpenseSharing.Api.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseSharing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseManagementController : ControllerBase
    {
        private readonly IExpenseManagementService _expenseManagementService;
        public ExpenseManagementController(IExpenseManagementService expenseManagementService)
        {
            _expenseManagementService = expenseManagementService;
        }

        [HttpPost("CreateExpense")]
        public async Task<IActionResult> CreateExpense([FromBody] CreateExpenseDto createExpenseDto)
        {
            if(ModelState.IsValid)
            {
                var res = await _expenseManagementService.CreateExpense(createExpenseDto);
                if (res == false)
                {
                    return BadRequest(new { Message = "Invalid" });
                }
                return Ok(new { Message = "Expense created" });
            }
            ModelState.AddModelError("", "Invalid");
            return BadRequest(ModelState);

        }

        [HttpGet("GetGroupExpenses/{groupId}")]
        public async Task<IActionResult> GetGroupExpenses(int groupId)
        {
            if(ModelState.IsValid)
            {
                var res =await _expenseManagementService.GetGroupExpenses(groupId);
                if (res != null)
                {
                    return Ok(res);
                }
            }
            ModelState.AddModelError("", "Invalid");
            return BadRequest(ModelState);



        }
    }
}
