using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_CarRental.Models
{
    [Table("ViewEvaluate")]
    public class ViewEvaluate
    {
        [Key]
        public int EvaluateID { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public string? Abstract { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsActive { get; set; }
        public int RangeStar { get; set; }
        public int Category { get; set; }
        public string? Status { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }

        [NotMapped]
        public string? CarName { get; set; }
    }
}
