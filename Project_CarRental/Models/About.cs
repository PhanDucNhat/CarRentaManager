using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_CarRental.Models
{
    [Table("About")]
    public class About
    {
        [Key]
        public int AboutID { get; set; }

		[StringLength(100, ErrorMessage = "Tiêu đề không được vượt quá 100 ký tự.")]
		public string? Title { get; set; }
		[StringLength(250, ErrorMessage = "Nội dung không được vượt quá 250 ký tự.")]
		public string? Contents { get; set; }
        public string? Images { get; set; }
        public bool? IsActive { get; set; }
        public int MenuID { get; set; }
    }
}
