using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_CarRental.Models
{
    [Table("About")]
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        public string? Title { get; set; }
        public string? Contents { get; set; }
        public string? Images { get; set; }
        public bool? IsActive { get; set; }
        public int MenuID { get; set; }
    }
}
