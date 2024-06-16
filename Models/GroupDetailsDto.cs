namespace ExpenseSharing.Api.Models
{
    public class GroupDetailsDto
    {
        public string GroupName { get; set; }
        public string Description { get; set; }
        public List<GroupMember> GroupMembers { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
