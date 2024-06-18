using ExpenseSharing.Api.Data;
using ExpenseSharing.Api.Models;
using ExpenseSharing.Api.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ExpenseSharing.Api.Repositories.Implementation
{
    public class GroupManagementRepository : IGroupManagementRepository
    {
        private readonly ApplicationDbContext _db;
        public GroupManagementRepository(ApplicationDbContext db)
        {
            _db=db;
        }
        public async Task<bool> CreateGroup(Groups group)
        {
            _db.Groups.Add(group);
           _db.SaveChanges();
            return true;
        }

        public async Task CreateGroupMembers(GroupMember groupMember)
        {
            _db.GroupMember.Add(groupMember);
            _db.SaveChanges();

        }

        public async Task<GroupDetailsDto> GetGroupDetails(int id)
        {
            //find the group record
            var group=_db.Groups.FirstOrDefault(g => g.Id == id);
            if (group == null)
            {
                return null;
            }

            //find the members within group
            var memberEmails = await _db.GroupMember
                .Where(gm => gm.GroupId == id)
                .Select(gm => gm.UserId)
                .ToListAsync();
            GroupDetailsDto dto = new GroupDetailsDto()
            {
               GroupName=group.GroupName,
               Description=group.Description,
               CreatedBy=group.CreatedByUserId,
               CreatedDate=group.CreatedDate,
               GroupMembers= memberEmails
            };
            return dto;
        }

        public async Task<List<UserBelongedGroupsDto>> GetUserBelongedGroups(string userEmail)
        {
            //search the group member table and find the group ids where the userEmail matches
            var groupIds=_db.GroupMember.Where(gm=>gm.UserId== userEmail).Select(gm => gm.GroupId).Distinct().ToList();

            List<UserBelongedGroupsDto> userGroups = new List<UserBelongedGroupsDto>();

            if (groupIds.Count == 0) { return null; }

            foreach (var groupId in groupIds)
            {
                var group=_db.Groups.FirstOrDefault(obj=>obj.Id == groupId);
                userGroups.Add(new UserBelongedGroupsDto()
                {
                    GroupId = group.Id,
                    GroupName = group.GroupName,
                    GroupDescription = group.Description,
                    CreatedBy = group.CreatedByUserId,

                });
            }
            return userGroups;
        }
    }
}
