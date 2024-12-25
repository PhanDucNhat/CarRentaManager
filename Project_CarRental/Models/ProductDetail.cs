using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_CarRental.Models
{
    [Table("ProductDetail")]
    public class ProductDetail
    {
        [Key]
        public int ProductDetailID { get; set; }
        public int ProductID { get; set; }
        public string? Images { get; set; }
        public int Seats { get; set; }
        public int Mileage { get; set; }
        public string? Transmission { get; set; }
        public string? Color { get; set; }
        public string? Fuel { get; set; }
        public string? Description { get; set; }
        public int OverTime { get; set; }
        public int ExceedKm { get; set; }
        public int OverNight { get; set; }
        public int Holiday { get; set; }
        public string? LongRoad { get; set; }
        public int PricesHour { get; set; }
        public int PricesDay { get; set; }
        public int PricesMonth { get; set; }
        public bool? IsActive { get; set; }

        [NotMapped]
        public string? CarName { get; set; }
    }
}
