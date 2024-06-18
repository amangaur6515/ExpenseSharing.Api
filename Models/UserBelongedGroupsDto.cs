namespace ExpenseSharing.Api.Models
{
    public class UserBelongedGroupsDto
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public string CreatedBy { get; set; }
    }
}
