using ExpenseSharing.Api.Models;

namespace ExpenseSharing.Api.Repositories.Abstract
{
    public interface IGroupManagementRepository
    {
        public Task<bool> CreateGroup(Groups group);
        public Task CreateGroupMembers(GroupMember groupMember);
        public Task<GroupDetailsDto> GetGroupDetails(int id);

        public Task<List<UserBelongedGroupsDto>> GetUserBelongedGroups(string userEmail);
        
    }
}
