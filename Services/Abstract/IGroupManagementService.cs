using ExpenseSharing.Api.Models;

namespace ExpenseSharing.Api.Services.Abstract
{
    public interface IGroupManagementService
    {
        public Task CreateGroup(CreateGroupDto createGroupDto);
        public Task<GroupDetailsDto> GetGroupDetailsDto(int id);
        public Task<List<UserBelongedGroupsDto>> GetUserBelongedGroups(string userEmail);
    }
}
