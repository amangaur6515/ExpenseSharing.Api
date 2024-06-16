using ExpenseSharing.Api.Data;
using ExpenseSharing.Api.Models;
using ExpenseSharing.Api.Repositories.Abstract;

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
    }
}
