using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_CarRental.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public int PostID { get; set; }
        public int UserID { get; set; }
        public string? Message { get; set; }
        public DateTime? CreateDateMessage { get; set; }
        public int CommentOrder { get; set; }
    }
}
