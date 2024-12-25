using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_CarRental.Models
{
    [Table("ViewComment")]
    public class ViewComment
    {
        [Key]
        public int CommentID { get; set; }
        public int PostID { get; set; }
        public int UserID { get; set; }
        public string? Message { get; set; }
        public DateTime? CreateDateMessage { get; set; }
        public int CommentOrder { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
        public string? Title { get; set; }
        public string? Images { get; set; }
        public bool? IsActive { get; set; }
    }
}
