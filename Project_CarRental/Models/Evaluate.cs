using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_CarRental.Models
{
    [Table("Evaluate")]
    public class Evaluate
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
    }
}
