using ExpenseSharing.Api.Models;
using ExpenseSharing.Api.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseSharing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupManagementController : ControllerBase
    {
        private readonly IGroupManagementService _groupManagementService;
        public GroupManagementController(IGroupManagementService groupManagementService)
        {
            _groupManagementService = groupManagementService;
        }

        [HttpPost("CreateGroup")]
        public async Task<IActionResult> CreateGroup([FromBody] CreateGroupDto createGroupDto)
        {
            await _groupManagementService.CreateGroup(createGroupDto);
            return Ok(createGroupDto);
        }

        [HttpGet("GetGroupDetails/{id}")]
        public async Task<IActionResult> GetGroupDetails(int id)
        {

        }
    }
}
