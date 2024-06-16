using System.ComponentModel.DataAnnotations;

namespace ExpenseSharing.Api.Models
{
    public class Groups
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string GroupName { get; set; }
        [Required]
        public string Description { get; set; }
        
        public DateTime CreatedDate { get; set; }
        [Required]
        public string CreatedByUserId { get; set; }

    }
}
