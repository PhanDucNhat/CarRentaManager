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
        public decimal? OverTime { get; set; }
        public decimal? ExceedKm { get; set; }
        public decimal? OverNight { get; set; }
        public decimal? Holiday { get; set; }
        public string? LongRoad { get; set; }
        public decimal? PricesHour { get; set; }
        public decimal? PricesDay { get; set; }
        public decimal? PricesMonth { get; set; }
        public bool? IsActive { get; set; }

        [NotMapped]
        public string? CarName { get; set; }
    }
}
