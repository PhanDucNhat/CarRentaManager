using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_CarRental.Models
{
    [Table("Footer")]
    public class Footer
    {
        [Key]
        public int FooterID { get; set; }
        public string? Abstract { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }
    }
}
