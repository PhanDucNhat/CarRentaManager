using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_CarRental.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string? CarName { get; set; }
        public bool? IsActive { get; set; }
        public int MenuID { get; set; }
        public int Category { get; set; }

        [NotMapped]
        public string? MenuName { get; set; }
    }
}
