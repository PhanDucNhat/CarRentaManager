using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_CarRental.Models
{
    [Table("Service")]
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }
        public string? Title { get; set; }
        public string? Contents { get; set; }
        public int MenuID { get; set; }
        public bool? IsActive { get; set; }
    }
}
