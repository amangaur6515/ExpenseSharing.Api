using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ExpenseSharing.Api.Models
{
    public class GroupMember
    {
        [Key]
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string UserId { get; set; }
        
    }
}
