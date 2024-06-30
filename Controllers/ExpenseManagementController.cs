using ExpenseSharing.Api.Models;
using ExpenseSharing.Api.Services.Abstract;
using ExpenseSharing.Api.Services.Implementation;
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
                return Ok(createExpenseDto);
            }
            ModelState.AddModelError("", "Invalid");
            return BadRequest(ModelState);

        }

        [HttpGet("GetGroupExpenses/{groupId}")]
        public async Task<IActionResult> GetGroupExpenses(int groupId)
        {
           
            
                var res =await _expenseManagementService.GetGroupExpenses(groupId);
                if (res != null)
                {
                    return Ok(res);
                }
                return BadRequest(new {Message="Invalid Id"});
            
        }

        [HttpGet("GetExpenseDetails/{expenseId}")]
        public async Task<IActionResult> GetExpenseDetails(int expenseId)
        {
            var res=await _expenseManagementService.GetExpenseDetails(expenseId);
            if(res != null)
            {
                return Ok(res);
            }
            return BadRequest(new { Message = "Invalid id" });
        }

        [HttpGet("SettleExpense/{expenseId}")]
        public async Task<IActionResult> SettleExpense(int expenseId)
        {
            var res=await _expenseManagementService.SettleExpense(expenseId);
            if (res)
            {
                return Ok(new { Message = "Expense settled successfully" });
            }
            return BadRequest(new { Message = "Expense settled successfully" });
        }


        //to be accessd by admin only
        [HttpGet("GetAllExpenses")]
        public async Task<IActionResult> GetAllExpenses()
        {
            var res = await _expenseManagementService.GetAllExpenses();
            return Ok(res);
        }
    }
}
