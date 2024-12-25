using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_CarRental.Models
{
	[Table("Rental")]
	public class Rental
	{
		[Key]
		public int RentalID { get; set; }
		public int UserID { get; set; }
		public int ProductID { get; set; }
		public string? PickUpLocation { get; set; }
		public string? DropOffLocation { get; set; }
		public DateTime? PickUpDate { get; set; }
		public DateTime? DropOffDate { get; set; }
		public TimeSpan? PickUpTime { get; set; }
		public bool? IsActive { get; set; }
		public string? Status { get; set; }
	}
}
