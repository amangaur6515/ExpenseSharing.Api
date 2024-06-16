namespace ExpenseSharing.Api.Models
{
    public class CreateGroupDto
    {
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public string CreatedByUserId { get; set; }
        public List<string> MemberEmails { get; set; } // List of member emails
    }
}
