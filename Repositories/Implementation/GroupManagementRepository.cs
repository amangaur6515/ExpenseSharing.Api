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
            var group=_db.Groups.FirstOrDefault(g => g.Id == id);
            if (group == null)
            {
                return null;
            }
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
    }
}
