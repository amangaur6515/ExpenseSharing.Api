using ExpenseSharing.Api.Models;
using ExpenseSharing.Api.Repositories.Abstract;
using ExpenseSharing.Api.Services.Abstract;

namespace ExpenseSharing.Api.Services.Implementation
{
    public class GroupManagementService : IGroupManagementService
    {
        private readonly IGroupManagementRepository _groupManagementRepository;
        public GroupManagementService(IGroupManagementRepository groupManagementRepository)
        {
            _groupManagementRepository = groupManagementRepository;
        }
        public async Task CreateGroup(CreateGroupDto  createGroupDto)
        {
            //some checks
            if (createGroupDto ==null )
            {
                return; 
            }

            //create a group object record
            Groups group = new Groups()
            {
                GroupName = createGroupDto.GroupName,
                CreatedByUserId = createGroupDto.CreatedByUserId,
                Description = createGroupDto.GroupDescription,
                CreatedDate= DateTime.Now,

            };

            //call repository to add group record
            bool res= await _groupManagementRepository.CreateGroup(group);
            
            //create group member record

            //created of the group will always be the member
            foreach(var email in createGroupDto.MemberEmails)
            {
                GroupMember member = new GroupMember()
                {
                    GroupId = group.Id,
                    UserId = email,

                };

                await _groupManagementRepository.CreateGroupMembers(member);
                
            }
            
        }
    }
}
