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
            var groupDetails=await _groupManagementService.GetGroupDetailsDto(id);
            if(groupDetails == null)
            {
                return BadRequest(new { Message = "Invalid ID" });
            }
            return Ok(groupDetails);
        }

        [HttpGet("GetUserBelongedGroups/{userEmail}")]
        public async Task<IActionResult> GetUserBelongedGroups(string userEmail)
        {
            var res =await _groupManagementService.GetUserBelongedGroups(userEmail);
            if(res == null)
            {
                return BadRequest(new { Message = "User does not exist" });
            }
            return Ok(res); 
        }
    }
}
